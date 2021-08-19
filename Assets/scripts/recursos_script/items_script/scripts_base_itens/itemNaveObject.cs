using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Novo Item para Nave Object", menuName = "Sistema de Inventário/Items/itemNave")]
public class itemNaveObject : itemObject
{
    public void Awake()
    {
        tipo = tiposItens.itemNave;
    }
}
