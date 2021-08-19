using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Novo Item Object", menuName = "Sistema de Inventário/Items/Default")]
public class defaultItem : itemObject
{
    public void Awake()
    {
        tipo = tiposItens.Default;
    }
}
