using UnityEngine;

namespace Foxy.Flipside
{

    public class SegmentBuilder : MonoBehaviour
    {

        [SerializeField] private float firstPopOffset;
        [SerializeField] private float basePopTime;
        [SerializeField] private Transform mapParent;
        [SerializeField] private float courseHeight;
        [SerializeField] private GameObject tilePrefab;

        private float lastPopTime;

        private void Awake() =>
            lastPopTime = firstPopOffset;

        public void Build(CourseSegment segment, Rng rng)
        {
            foreach (var tile in segment.Tiles) BuildTile(tile, rng);
        }

        private void BuildTile(CourseTile tile, Rng rng)
        {
            var pos = new Vector3(tile.Position.x, courseHeight, tile.Position.y);
            var tileGo = Instantiate(tilePrefab, pos, Quaternion.identity, mapParent);

            var popTime = CalculatePopTime(rng);
            tileGo.GetComponent<ObjectPopper>().Init(popTime);

            lastPopTime = popTime;
        }

        private float CalculatePopTime(Rng rng) =>
            lastPopTime + basePopTime * rng.InRange(0.5f, 1.5f) + rng.InRange(-0.5f, 0.5f);

    }

}