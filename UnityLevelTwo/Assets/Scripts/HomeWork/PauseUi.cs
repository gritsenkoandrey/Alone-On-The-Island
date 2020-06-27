using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public sealed class PauseUi : BaseObjectScene
{
    #region Fields

    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioMixerGroup _mixerGroup;

    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private ButtonUi _resume;
    [SerializeField] private ButtonUi _quit;
    [SerializeField] private ButtonUi _mainMenu;
    [SerializeField] private SliderUi _volume;

    [SerializeField] private TextUi _text;

    //private float _value;
    private bool _isPaused;
    private int _mainMenuScene = 0;
    private CharacterController _controller;
    private AudioMixerSnapshot _pause;
    private AudioMixerSnapshot _unPause;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _controller = FindObjectOfType<CharacterController>();
        _pause = _mixer.FindSnapshot("Paused");
        _unPause = _mixer.FindSnapshot("UnPaused");

        _resume.GetText.text = LangManager.Instance.Text("PauseMenu", "Resume");
        _resume.GetControl.onClick.AddListener(delegate
        {
            Pause();
        });

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

        _volume.GetText.text = LangManager.Instance.Text("PauseMenu", "Volume");
        _volume.Interactable(true);

        _text.GetText.text = LangManager.Instance.Text("PauseMenu", "PauseMenu");
    }

    // доработать через PauseController
    //private void Update()
    //{
    //    _mixerGroup.audioMixer.GetFloat("MasterVolume", out _value);
    //    _volume.GetText.text = $"{_value + 100}";
    //}

    #endregion


    #region Methods

    public void StartCondition()
    {
        _pausePanel.SetActive(false);
        _gamePanel.SetActive(true);
        _gameOverPanel.SetActive(false);
    }

    public void Pause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            Time.timeScale = 0.0f;
            _pause.TransitionTo(0.0001f);
            _pausePanel.SetActive(true);
            _gamePanel.SetActive(false);
            _controller.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            _unPause.TransitionTo(0.0001f);
            _pausePanel.SetActive(false);
            _gamePanel.SetActive(true);
            _controller.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void AudioVolume(float sliderValue)
    {
        _mixer.SetFloat("MasterVolume", sliderValue);
        _mixerGroup.audioMixer.GetFloat("MasterVolume", out sliderValue);
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

    //private void OnGUI()
    //{
    //    var input = Event.current;
    //    if (input.isKey)
    //    {
    //        var inputText = input.keyCode.ToString();
    //        if (!inputText.Contains("None"))
    //        {
    //            _text.text = inputText;
    //        }
    //    }
    //}

    #endregion
}