using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneMove : MonoBehaviour
{

    public void Open(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}