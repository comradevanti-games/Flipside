using UnityEngine;

namespace Foxy.Flipside
{

    public abstract class SegmentGen : ScriptableObject
    {

        [SerializeField] private int minDistance;

         public int MinDistance => minDistance;


        public abstract CourseSegment Generate(Vector2Int startPos, Rng rng);

    }

}