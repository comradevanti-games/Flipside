using UnityEngine;
using UnityEngine.Events;

namespace Foxy.Flipside
{

    public class DistanceTracker : MonoBehaviour
    {

        public UnityEvent<int> onMaxDistanceChanged;
        public UnityEvent onMilestoneReached;

        private int lastMilestone;
        private int maxDistance;


        private float TotalDistance =>
            transform.position.x;

        private float DistanceFromLastMilestone =>
            TotalDistance - lastMilestone;

        private bool ReachedMilestone =>
            DistanceFromLastMilestone >= CourseSegment.Length;


        private void Awake() =>
            onMaxDistanceChanged.Invoke(0);

        private void Update()
        {
            while (ReachedMilestone)
            {
                lastMilestone += CourseSegment.Length;
                onMilestoneReached.Invoke();
            }

            if (TotalDistance >= maxDistance + 1)
            {
                maxDistance = (int)TotalDistance;
                onMaxDistanceChanged.Invoke(maxDistance);
            }
        }

    }

}