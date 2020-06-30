using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public sealed class GameOverUi : BaseObjectScene
{
    #region Fields

    [SerializeField] private AudioMixer _mixer;
    //[SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private AudioClip _audioClip;

    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private ButtonUi _quit;
    [SerializeField] private ButtonUi _mainMenu;

    [SerializeField] private TextUi _text;

    private int _mainMenuScene = 0;
    private CharacterController _controller;
    private AudioSource _audioSource;
    private AudioMixerSnapshot _pause;
    private AudioMixerSnapshot _unPause;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _controller = FindObjectOfType<CharacterController>();
        _audioSource = FindObjectOfType<AudioSource>();
        _pause = _mixer.FindSnapshot("Paused");
        _unPause = _mixer.FindSnapshot("UnPaused");

        _mainMenu.GetText.text = LangManager.Instance.Text("PauseMenu", "MainMenu");
        _mainMenu.GetControl.onClick.AddListener(delegate
        {
            LoadMainMenu();
        });

        _quit.GetText.text = LangManager.Instance.Text("PauseMenu", "Quit");
        _quit.GetControl.onClick.AddListener(delegate
        {
            QuitGame();
        });

        _text.GetText.text = LangManager.Instance.Text("PauseMenu", "GameOver");
    }

    #endregion


    #region Methods

    public void GameOver()
    {
        _pausePanel.SetActive(false);
        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;
        //_pause.TransitionTo(0.0001f);
        this._audioSource.PlayOneShot(_audioClip);
        _controller.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        _unPause.TransitionTo(0.0001f);
        _controller.enabled = true;
        ServiceLocator.Cleanup();
        ServiceLocatorMonoBehaviour.Cleanup();
        SceneManager.LoadScene(_mainMenuScene);
    }

    #endregion
}