using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Terrain Modifier", order = 1)]
public class TerrainModifier : MonoBehaviour
{
    [SerializeField] private TerrainModifierData _data;

    public void OnTerrainEnter()
    {
        // pas de data toe op de speler
    }
}
