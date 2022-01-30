using UnityEngine;
using UnityEngine.Events;

namespace Foxy.Flipside
{

    public class XCoordinateRepeater : MonoBehaviour
    {

        public UnityEvent onRepeat;

        [SerializeField] private float repeatX;
        [SerializeField] private float startX;


        private Vector3 LocalPos
        {
            get => transform.localPosition;
            set => transform.localPosition = value;
        }

        private float LocalX
        {
            get => LocalPos.x;
            set => LocalPos = new Vector3(value, LocalPos.y, LocalPos.z);
        }

        private bool ShouldRepeat =>
            LocalX <= repeatX;


        private void Update()
        {
            if (ShouldRepeat)
                Repeat();
        }

        private void Repeat()
        {
            LocalX = startX; 
            onRepeat.Invoke();
        }

    }

}