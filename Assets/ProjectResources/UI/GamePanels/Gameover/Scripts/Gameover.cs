using UnityEngine;

public class Gameover : MonoBehaviour
{
    private GamePanel _gamePanel;

    private void Awake()
    {
        _gamePanel = new GamePanel();
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
