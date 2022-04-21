using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class RotationSprite : ScriptableObject
{
    [System.Serializable]
    public class Data
    {
        public Sprite sprite;
        public float rotation;
    }

    public List<Data> spriteRotations;

    public Sprite GetSpriteFromRotation(float rotation)
    {
        // Sprite result = null;

        var closest = spriteRotations.Select( n => new { n, distance = Mathf.Abs( n.rotation - rotation ) } )
            .OrderBy( p => p.distance )
            .First().n.sprite;

        return closest;
    }
}
