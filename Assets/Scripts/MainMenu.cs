using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void CloseWindow();
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
                Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        #endif
        #if (UNITY_EDITOR)
                UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE) 
            Application.Quit();
        #elif (UNITY_WEBGL)
            CloseWindow();

        #endif
    }
}
