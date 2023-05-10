using Cinemachine;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("PlayerSpawnSettings")]
    [Tooltip("Prefab")]
    [SerializeField] private PlayerMovement _player;
    [Tooltip("OnScene")]
    [SerializeField] private Transform _playerSpawner;

    [Header("PlayerMovementSettings")]
    [Tooltip("Prefab")]
    [SerializeField] private float _playerMaxSpeed;
    [Tooltip("Prefab")]
    [SerializeField] private float _playerForceFactor;

    [Header("InputSettings")]
    [Tooltip("Prefab")]
    [SerializeField] private InputHandler _inputHandler;
    [Tooltip("OnScene")]
    [SerializeField] private JoystickManager _joystickManager;

    [Header("CameraSettings")]
    [Tooltip("OnScene")]
    [SerializeField] private CinemachineVirtualCamera _cmVirtualCamera;

    [Header("UISettings")] // Un the future make UI controller
    [Tooltip("OnScene")]
    [SerializeField] private GameObject _finishPanel;
    [Tooltip("OnScene")]
    [SerializeField] private GameObject _gameoverPanel;
    [Tooltip("OnScene")]
    [SerializeField] private GameObject _gamePanel;

    private KillZone[] _killZones;
    private Finish _finish;

    private void Awake()
    {
        Time.timeScale = 1;

        InitializePlayer();
        InitializeKillZones();
        InitializeFinish();
        InitializeInputHandler();
    }

    private void Gameover()
    {
        Time.timeScale = 0;
        _gameoverPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }

    private void Finish()
    {
        Time.timeScale = 0;
        _finishPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }

    private void InitializeKillZones()
    {
        _killZones = FindObjectsByType<KillZone>(FindObjectsSortMode.None);

        foreach (var killZone in _killZones)
        {
            killZone.PlayerEntered += Gameover;
        }
    }

    private void InitializeFinish()
    {
        _finish = FindFirstObjectByType<Finish>();

        _finish.PlayerEntered += Finish;
    }

    private void InitializePlayer()
    {
        _player = Instantiate(_player, _playerSpawner.position, _playerSpawner.rotation).GetComponent<PlayerMovement>();
        _player.SetMovementSettings(_playerMaxSpeed, _playerForceFactor);

        _cmVirtualCamera.Follow = _player.transform;
    }

    private void InitializeInputHandler()
    {
        _inputHandler = Instantiate(_inputHandler).GetComponent<InputHandler>();
        
        if (_joystickManager == null)
        {
            Debug.LogError("No reference to JoystickManager");
            _joystickManager = FindFirstObjectByType<JoystickManager>();

            if (_joystickManager == null)
            {
                Debug.LogError("JoystickManager not found on scene");
                return;
            }
        }

        _inputHandler.SetSettings(_player, _joystickManager);
    }
}
