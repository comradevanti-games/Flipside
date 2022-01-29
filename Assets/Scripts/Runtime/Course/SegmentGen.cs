using UnityEngine;

namespace Foxy.Flipside
{

    public abstract class SegmentGen : ScriptableObject
    {

        [field: SerializeField] public int MinDistance { get; }


        public abstract CourseSegment Generate(Vector2Int startPos, Rng rng);

    }

}