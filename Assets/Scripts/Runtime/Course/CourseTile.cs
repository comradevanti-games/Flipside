using UnityEngine;

namespace Foxy.Flipside
{

    public readonly struct CourseTile
    {

        public Vector2Int Position { get; }


        public CourseTile(Vector2Int position) =>
            Position = position;

    }

}