using UnityEngine;
using UnityEngine.Events;

namespace Foxy.Flipside
{

    public class DistanceTracker : MonoBehaviour
    {

        public UnityEvent onMilestoneReached;

        private float lastMilestone;


        private float TotalDistance =>
            transform.position.x;

        private float DistanceFromLastMilestone =>
            TotalDistance - lastMilestone;

        private bool ReachedMilestone =>
            DistanceFromLastMilestone >= CourseSegment.Length;


        private void Update()
        {
            while (ReachedMilestone)
            {
                lastMilestone += CourseSegment.Length;
                onMilestoneReached.Invoke();
            }
        }

    }

}