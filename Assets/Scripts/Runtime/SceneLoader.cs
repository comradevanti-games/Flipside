using UnityEngine;
using UnityEngine.SceneManagement;

namespace Foxy.Flipside
{

    public class SceneLoader : MonoBehaviour
    {

        public void Load(string sceneName) =>
            SceneManager.LoadScene(sceneName);

    }

}