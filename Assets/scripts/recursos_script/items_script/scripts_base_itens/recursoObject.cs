using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Novo Recurso Object", menuName = "Sistema de Inventário/Items/Recurso")]
public class recursoObject : itemObject
{
    public void Awake()
    {
        tipo = tiposItens.recurso;
    }
}
