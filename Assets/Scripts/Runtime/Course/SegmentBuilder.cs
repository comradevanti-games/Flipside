using UnityEngine;

namespace Foxy.Flipside
{

    public class SegmentBuilder : MonoBehaviour
    {

        [SerializeField] private Transform mapParent;
        [SerializeField] private float courseHeight;
        [SerializeField] private GameObject tilePrefab;

        private int tileIndex = 0;

        public void Build(CourseSegment segment)
        {
            foreach (var tile in segment.Tiles) BuildTile(tile);
        }

        private void BuildTile(CourseTile tile)
        {
            var pos = new Vector3(tile.Position.x, courseHeight, tile.Position.y);
            var tileGo = Instantiate(tilePrefab, pos, Quaternion.identity, mapParent);
            
            tileGo.GetComponent<ObjectPopper>().Init(tileIndex);

            tileIndex++;
        }

    }

}