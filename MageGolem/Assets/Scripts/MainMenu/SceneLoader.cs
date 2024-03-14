using UnityEngine;

namespace MainMenu
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadMainScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
