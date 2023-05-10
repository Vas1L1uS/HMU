using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene(GlobalConstVars.LEVEL1_INDEX);
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene(GlobalConstVars.LEVEL2_INDEX);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene(GlobalConstVars.LEVEL3_INDEX);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene(GlobalConstVars.LEVEL4_INDEX);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
