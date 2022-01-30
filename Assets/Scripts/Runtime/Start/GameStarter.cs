using UnityEngine;
using UnityEngine.SceneManagement;

namespace Foxy.Flipside
{

    public class GameStarter : MonoBehaviour
    {

        public void StartGame() => 
            SceneManager.LoadScene("Main");

    }

}