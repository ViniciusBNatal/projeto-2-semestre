using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleSonic : MonoBehaviour
{
    public invetarioObject inventario;
    public LayerMask layerMascara;//quais layers vai ter verificação de colisão
    public Vector3 diferenca;
    private Rigidbody2D rb;
    private Animator animator;
    private const float RAIO = 0.05f;  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        diferenca = new Vector3(0, 0.15f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxis("Horizontal");

        if (horz != 0)
        {
            animator.SetBool("CORRENDO", true);
            transform.Translate(0.75f * Time.deltaTime*horz, 0, 0);//anda o personagem direita/esquerda
            if (horz < 0)
                transform.localScale = new Vector3(-1, 1, 1);//vira personagem para esquerda
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            animator.SetBool("CORRENDO", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, 3f), ForceMode2D.Impulse);
            animator.SetTrigger("PULAR");
            animator.SetBool("NOCHAO", false);
        }
    }
        private void FixedUpdate()
        {
            Collider2D[] colisoes = Physics2D.OverlapCircleAll(transform.position - diferenca, RAIO, layerMascara);
        if (colisoes.Length == 0)
            animator.SetBool("NOCHAO", false);
        else
            animator.SetBool("NOCHAO", true);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position - diferenca, RAIO);
    }
    private void OnTriggerEnter2D(Collider2D collision)//quando o jogador passa por algo com trriger ativado, verifica se é um item e o adicona no inventário
    {
        var item = collision.GetComponent<item>();
        if(item)
        {
            inventario.adicionarItem(item.objeto, 1);
            Destroy(collision.gameObject);
        }
    }
    private void OnApplicationQuit()
    {
        inventario.Container.Clear();
    }
}
