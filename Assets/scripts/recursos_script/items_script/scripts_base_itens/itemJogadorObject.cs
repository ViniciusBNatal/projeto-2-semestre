using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Novo Item para Jogador Object", menuName = "Sistema de Inventário/Items/itemJogador")]
public class itemJogadorObject : itemObject
{
    public void Awake()
    {
        tipo = tiposItens.itemJogador;
    }
}
