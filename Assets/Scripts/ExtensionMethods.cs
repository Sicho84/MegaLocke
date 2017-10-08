using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods

{
    public static Vector2 toVector2 (this Vector3 vect3)
    {
        return new Vector2(vect3.x, vect3.y);
    }
}
