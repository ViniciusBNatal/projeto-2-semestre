using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "Novo Inventário", menuName = "Sistema de Inventário/Inventário")]
public class invetarioObject : ScriptableObject
{
    public List<SlotInventario> Container = new List<SlotInventario>();// o nome da variável que contem todo o inventario é Container
    public void adicionarItem(itemObject _item, int _valor)//se possui o item adicona x na posição, senão, cria um nvo slot
    {
        bool temItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].adicionarQuantidade(_valor);
                temItem = true;
                break;
            }
        }
        if (!temItem)
        {
            Container.Add(new SlotInventario(_item, _valor));
        }
    }
}

[System.Serializable]
public class SlotInventario
{
    public itemObject item;
    public int quantidade;
    public SlotInventario(itemObject _item, int _quantidade)
    {
        item = _item;
        quantidade = _quantidade;

    }
    public void adicionarQuantidade (int valor)
    {
        quantidade += valor;
    }
}
