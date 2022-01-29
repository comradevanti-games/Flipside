using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Foxy.Flipside.Segments
{

    [CreateAssetMenu(menuName = "Flipside/Segmentgen/Straight", fileName = "New gen")]
    public class StraightSegmentGen : SegmentGen
    {

        public override CourseSegment Generate(Vector2Int startPos, Rng rng)
        {
            IEnumerable<CourseTile> GenTiles()
            {
                for (var i = 0; i < CourseSegment.Length; i++)
                {
                    var pos = new Vector2Int(startPos.x + i + 1, startPos.y);
                    yield return new CourseTile(pos);
                }
            }

            return new CourseSegment(GenTiles().ToArray());
        }

    }

}