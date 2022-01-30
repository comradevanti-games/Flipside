using UnityEngine;

namespace Foxy.Flipside
{

    public class MousePoint : MonoBehaviour
    {

        [SerializeField] private float planeHeight;
        [SerializeField] private Camera cam;


        private Plane HitPlane => new Plane(new Vector3(-1, planeHeight, 1),
                                            new Vector3(1, planeHeight, 1),
                                            new Vector3(-1, planeHeight, -1));

        public static Vector2 OnScreen => Input.mousePosition;

        public Vector3? OnPlane
        {
            get
            {
                var ray = cam.ScreenPointToRay(OnScreen);
                if (HitPlane.Raycast(ray, out var distance))
                    return ray.GetPoint(distance);
                return null;
            }
        }

    }

}