using UnityEngine;

public class GameMenuPanel : MonoBehaviour
{
    private GamePanel _gamePanel;

    private void Awake()
    {
        _gamePanel = new GamePanel();
    }

    public void Continue()
    {
        Time.timeScale = 1;
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
