using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public sealed class OptionsMenu : BaseMenu
{
    [SerializeField] private GameObject _optionsPanel;

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private DropdownUi _dropdownQuality;
    [SerializeField] private DropdownUi _dropdownResolution;
    [SerializeField] private ButtonUi _back;
    [SerializeField] private SliderUi _audio;
    [SerializeField] private ToggleUi _toggle;

    private Resolution[] _resolution;
    private List<string> _resolutionsList;

    private bool _isFullScreen;
    private float _value;
    private string _textVolume;

    private void Start()
    {
        _back.GetText.text = LangManager.Instance.Text("OptionsMenuItems", "Back");
        _back.GetControl.onClick.AddListener(delegate
        {
            Back();
        });

        _toggle.GetText.text = LangManager.Instance.Text("OptionsMenuItems", "Screen");
        _toggle.Interactable(true);

        _dropdownQuality.GetText.text = LangManager.Instance.Text("OptionsMenuItems", "Game");
        _dropdownQuality.Interactable(true);

        _dropdownResolution.GetText.text = LangManager.Instance.Text("OptionsMenuItems", "Video");
        _dropdownResolution.Interactable(true);
        ResolutionStart();

        _audio.GetText.text = LangManager.Instance.Text("OptionsMenuItems", "Sound");
        _textVolume = _audio.GetText.text;
        _audio.Interactable(true);
    }

    private void Update()
    {
        ShowAudioVolume();
    }

    private void LoadVideoOptions()
    {
        Interface.Execute(InterfaceObject.VideoOptions);
    }

    private void LoadSoundOptions()
    {
        Interface.Execute(InterfaceObject.AudioOptions);
    }

    private void LoadGameOptions()
    {
        Interface.Execute(InterfaceObject.GameOptions);
    }

    private void Back()
    {
        Interface.Execute(InterfaceObject.MainMenu);
    }

    public override void Hide()
    {
        if (!IsShow) return;
        IsShow = false;
        _optionsPanel.gameObject.SetActive(false);
        IsShow = false;
    }

    public override void Show()
    {
        if (IsShow) return;
        IsShow = true;
        _optionsPanel.gameObject.SetActive(true);
        IsShow = true;
    }

    // метод управления разрешением экрана
    public void FullScreenToggle()
    {
        _isFullScreen = !_isFullScreen;
        Screen.fullScreen = _isFullScreen;
    }

    // метод управления звуком
    public void AudioVolume(float value)
    {
        _audioMixer.SetFloat("MasterVolume", value);
    }

    // метод управления качеством изображения
    public void Quality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    // метод для смены разрешения
    public void Resolution(int r)
    {
        Screen.SetResolution(_resolution[r].width, _resolution[r].height, _isFullScreen);
    }

    private void ResolutionStart()
    {
        _resolutionsList = new List<string>(); // создаем новый список
        _resolution = Screen.resolutions; // получаем разрешения
                                          // пробегаем по массиву из полученных разрешений
        for (int i = 0; i < _resolution.Length; i++)
        {
            _resolutionsList.Add($"{_resolution[i].width}x{_resolution[i].height}");
        }
        _dropdownResolution.ClearResolutionList(); // очищаем список dropdown
        _dropdownResolution.AddResolutionList(_resolutionsList); // записываем разрешение в список
    }

    public void ShowAudioVolume()
    {
        _audioMixer.GetFloat("MasterVolume", out _value);
        _value = (_value + 50) / 0.5f;
        _audio.GetText.text = $"{_textVolume}: {_value:0}%";
    }
}