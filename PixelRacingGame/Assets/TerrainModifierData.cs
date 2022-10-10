using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainModifierData : ScriptableObject
{
    [SerializeField][Range(0, 1)] private float _rangeModifier = 1;
}
