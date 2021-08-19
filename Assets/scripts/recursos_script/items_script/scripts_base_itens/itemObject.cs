using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tiposItens
{
    recurso,
    itemJogador,
    itemNave,
    Default
}
public abstract class itemObject : ScriptableObject
{
    public GameObject prefab;
    public tiposItens tipo;
    [TextArea(15,20)]
    public string descricaoItem;
}
