using UnityEngine.SceneManagement;

public class GamePanel
{
    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(GlobalConstVars.MAINMENU_INDEX);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Possible error
    }
}