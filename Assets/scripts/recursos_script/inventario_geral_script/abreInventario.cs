using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class abreInventario : MonoBehaviour
{
    public invetarioObject inventario;
    public float X_ENTRE_OS_ITENS;
    public float Y_ENTRE_OS_ITENS;
    public float X_INICIAL;
    public float Y_INICIAL;
    public int NUMERO_DE_COLUNAS;
    Dictionary<SlotInventario, GameObject> itemsDisplayed = new Dictionary<SlotInventario, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        criaDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        atualizaDisplay();
    }
    public void atualizaDisplay()
    {
        for (int i = 0; i < inventario.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventario.Container[i]))
            {
                itemsDisplayed[inventario.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventario.Container[i].quantidade.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventario.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = pegaPosicao(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventario.Container[i].quantidade.ToString("n0");
                itemsDisplayed.Add(inventario.Container[i], obj);
            }
        }
    }
    public void criaDisplay()
    {
        for (int i = 0; i < inventario.Container.Count; i++)
        {
            var obj = Instantiate(inventario.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = pegaPosicao(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventario.Container[i].quantidade.ToString("n0");
            itemsDisplayed.Add(inventario.Container[i], obj);
        }
    }
    public Vector3 pegaPosicao(int i)
    {
        return new Vector3(X_INICIAL + (X_ENTRE_OS_ITENS * (i % NUMERO_DE_COLUNAS)), Y_INICIAL + (-Y_ENTRE_OS_ITENS * (i / NUMERO_DE_COLUNAS)), 0f);
    } 
}
