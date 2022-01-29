using System.Linq;
using Foxy.Flipside.Runtime;
using UnityEngine;

namespace Foxy.Flipside
{

    public class CourseGen : MonoBehaviour
    {

        [SerializeField] private SegmentGen[] segmentGenerators;

        
        private SegmentGen GetRandomSegmentGenerator(int distance, Rng rng)
        {
            var possibleGenerators = segmentGenerators.Where(it => distance >= it.MinDistance).ToArray();
            return possibleGenerators.RandomItem(rng);
        }

        public CourseSegment GenerateNext(CourseSegment? lastSegment, Rng rng)
        {
            var startPos = lastSegment?.LastPos ?? Vector2Int.zero;
            return GetRandomSegmentGenerator(startPos.x, rng).Generate(startPos, rng);
        }

    }

}