using UnityEngine;

namespace Foxy.Flipside
{

    public class TransformFollow : MonoBehaviour
    {

        [SerializeField] private Transform targetTransform;
        [SerializeField] [Range(0, 1)] private float smoothness;
        [SerializeField] private float speed;
        [SerializeField] private Vector3 offset;


        private Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        private Vector3 TargetPosition => targetTransform.position;


        private void LateUpdate() =>
            Move();

        private void Move()
        {
            var nextPos = Vector3.Lerp(Position - offset, TargetPosition, smoothness) + offset;
            Position = Vector3.MoveTowards(Position, nextPos, speed * Time.deltaTime);
        }

    }

}