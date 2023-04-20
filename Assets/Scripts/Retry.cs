using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public void RetryOnClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
