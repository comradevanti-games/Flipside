using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Foxy.Flipside
{

    [CreateAssetMenu(menuName = "Flipside/Segmentgen/Noise", fileName = "New gen")]
    public class NoiseSegmentGen : SegmentGen
    {

        [SerializeField] private int minDist;
        [SerializeField] private int maxDist;

        public override CourseSegment Generate(Vector2Int startPos, Rng rng)
        {
            IEnumerable<CourseTile> GenTiles()
            {
                var pos = startPos;
                for (var _ = 0; _ < CourseSegment.Length; _++)
                {
                    var dist = rng.InRange(minDist, maxDist);
                    pos.x++;
                    pos.y += rng.CoinToss() ? dist : -dist;
                    yield return new CourseTile(pos);
                }
            }

            return new CourseSegment(GenTiles().ToArray());
        }

    }

}