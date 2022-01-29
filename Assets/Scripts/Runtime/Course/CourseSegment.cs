using System.Linq;
using UnityEngine;

namespace Foxy.Flipside
{

    public struct CourseSegment
    {

        public const int Length = 10;
        
        public CourseTile[] Tiles { get; }

        public Vector2Int StartPos => Tiles.First().Position;

        public Vector2Int LastPos => Tiles.Last().Position;


        public CourseSegment(CourseTile[] tiles) =>
            Tiles = tiles;

    }

}