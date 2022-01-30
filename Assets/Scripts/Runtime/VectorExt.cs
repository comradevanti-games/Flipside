using UnityEngine;

namespace Foxy.Flipside
{

    public static class VectorExt
    {

        public static Vector3 Flat(this Vector3 v) =>
            new Vector3(v.x, 0, v.z);

        public static Vector3 Lift45(this Vector3 v) =>
            new Vector3(v.x, v.magnitude, v.z);

    }

}