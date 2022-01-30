using UnityEngine;

namespace Foxy.Flipside
{

    public class ParallaxElement : MonoBehaviour
    {

        [SerializeField] [Range(1, 100)] private float distance;
        [SerializeField] private Transform camTransform;

        private Vector3 lastCamPos;


        private Vector3 CamPos => camTransform.position;

        private Vector3 Pos
        {
            get => transform.position;
            set => transform.position = value;
        }
        
        private void Awake() => 
            lastCamPos = CamPos;

        private void LateUpdate()
        {
            var delta = CamPos - lastCamPos;
            Pos -= delta / distance;
            lastCamPos = CamPos;
        }

    }

}