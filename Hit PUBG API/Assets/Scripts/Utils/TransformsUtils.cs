using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Utils
{
    public static class TransformsUtils
    {
        public static void CleanChildren(this Transform transform)
        {
            var count = transform.childCount;
            var gos = new GameObject[count];

            for (var i = 0; i < count; i++)
            {
                gos[i] = transform.GetChild(i).gameObject;
            }

            for (var i = 0; i < count; i++)
            {
                Object.Destroy(gos[i]);
            }
            
        }
    }
}