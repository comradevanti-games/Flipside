using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Foxy.Flipside.Segments
{

    [CreateAssetMenu(menuName = "Flipside/Segmentgen/U", fileName = "New gen")]
    public class USegmentGen : SegmentGen
    {

        [SerializeField] private int radius;
        
        
        public override CourseSegment Generate(Vector2Int startPos, Rng rng)
        {
            var dir = rng.CoinToss() ? 1 : -1;
            
            
            IEnumerable<CourseTile> GenTiles()
            {
                var pos = new Vector2Int(startPos.x, startPos.y);

                for (var i = 0; i < 2; i++)
                {
                    pos.x++;
                    yield return new CourseTile(pos);
                }
                
                for (var i = 0; i < radius; i++)
                {
                    pos.y += dir;
                    yield return new CourseTile(pos);
                }
                
                for (var i = 0; i < CourseSegment.Length - 2; i++)
                {
                    pos.x++;
                    yield return new CourseTile(pos);
                }
                
                for (var i = 0; i < radius; i++)
                {
                    pos.y -= dir;
                    yield return new CourseTile(pos);
                }
                
                pos.x++;
                yield return new CourseTile(pos);
            }

            return new CourseSegment(GenTiles().ToArray());
        }

    }

}