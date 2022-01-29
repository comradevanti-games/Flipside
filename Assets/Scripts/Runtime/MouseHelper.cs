using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foxy.Flipside
{
    public class MouseHelper : MonoBehaviour
    {

        public static MouseHelper Instance;

        private Plane templatePlane = new Plane(Vector3.zero, 3.0f);
        private Camera camera;

        // Start is called before the first frame update
        void Start()
        {
            Instance = this;
            camera = Camera.main;
        }

        public Vector3 TryGetMousePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = camera.ScreenPointToRay(mousePos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                return hit.point;
            }

            Plane translatedPlane =
                Plane.Translate(templatePlane, camera.ScreenToWorldPoint(mousePos) - templatePlane.normal);
            float dist;
            if (translatedPlane.Raycast(ray, out dist))
            {
                return ray.GetPoint(dist);
            }

            return Vector3.zero;
        }
    }
}