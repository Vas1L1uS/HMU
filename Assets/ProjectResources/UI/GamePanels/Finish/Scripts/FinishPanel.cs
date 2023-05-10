using UnityEngine;

public class FinishPanel :MonoBehaviour
{
    private GamePanel _gamePanel;

    private void Awake()
    {
        _gamePanel = new GamePanel();
    }

    public void Next()
    {
        _gamePanel.LoadNextScene();
    }

    public void Restart()
    {
        _gamePanel.ReloadCurrentScene();
    }

    public void Menu()
    {
        _gamePanel.LoadMenu();
    }
}
