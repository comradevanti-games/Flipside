using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Foxy.Flipside.Segments
{

    [CreateAssetMenu(menuName = "Flipside/Segmentgen/U", fileName = "New gen")]
    public class USegmentGen : SegmentGen
    {

        [SerializeField] private int minHeight;
        [SerializeField] private int maxHeight;
        [SerializeField] private int minWidth;
        [SerializeField] private int maxWidth;
        
        
        public override CourseSegment Generate(Vector2Int startPos, Rng rng)
        {
            var dir = rng.CoinToss() ? 1 : -1;
            var height = rng.InRange(minHeight, maxHeight);
            var width = rng.InRange(minWidth, maxWidth);
            var rest = CourseSegment.Length - width;
            var offset = rng.InRange(0, rest);
            
            IEnumerable<CourseTile> GenTiles()
            {
                var pos = new Vector2Int(startPos.x, startPos.y);

                for (var _ = 0; _ < rest - offset; _++)
                {
                    pos.x++;
                    yield return new CourseTile(pos);
                }
                
                for (var _ = 0; _ < height; _++)
                {
                    pos.y += dir;
                    yield return new CourseTile(pos);
                }
                
                for (var _ = 0; _ < width; _++)
                {
                    pos.x++;
                    yield return new CourseTile(pos);
                }
                
                for (var _ = 0; _ < height; _++)
                {
                    pos.y -= dir;
                    yield return new CourseTile(pos);
                }
                
                for (var _ = 0; _ < offset; _++)
                {
                    pos.x++;
                    yield return new CourseTile(pos);
                }
            }

            return new CourseSegment(GenTiles().ToArray());
        }

    }

}