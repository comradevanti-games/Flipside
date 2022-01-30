using TMPro;
using UnityEngine;

namespace Foxy.Flipside
{

    public class DistanceDisplay : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI display;


        private string Text
        {
            set => display.text = value;
        }
        

        public void Display(int distance) => 
            Text = $"{distance}m";

    }

}