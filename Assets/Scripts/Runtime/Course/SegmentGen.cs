using UnityEngine;

namespace Foxy.Flipside
{

    public abstract class SegmentGen : ScriptableObject
    {

        [SerializeField] private int minDistance;
        [SerializeField] private int maxDistance;

         public int MinDistance => minDistance;
         
         public int MaxDistance => maxDistance;


        public abstract CourseSegment Generate(Vector2Int startPos, Rng rng);

    }

}