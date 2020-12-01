using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class MainMenu : BaseMenu
{
    #region Fields

    [SerializeField] private GameObject _mainPanel;

    [SerializeField] private ButtonUi _newGame;
    [SerializeField] private ButtonUi _options;
    [SerializeField] private ButtonUi _quit;

    [SerializeField] private ButtonUi _langRu;
    [SerializeField] private ButtonUi _langEn;
    [SerializeField] private TextUi _langText;

    private OptionsMenu _optionsMenu;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _optionsMenu = GetComponent<OptionsMenu>();

        _newGame.GetText.text = LangManager.Instance.Text("MainMenuItems", "NewGame");
        _newGame.GetControl.onClick.AddListener(delegate
        {
            //LoadNewGame($"{SceneManagerHelper.Instance.Scenes.Game.SceneAsset.name}");
            //LoadNewGame("Scene");
            LoadNewGameIndex(1);
        });

        _options.GetText.text = LangManager.Instance.Text("MainMenuItems", "Options");
        _options.GetControl.onClick.AddListener(delegate
        {
            ShowOptions();
        });

        _quit.GetText.text = LangManager.Instance.Text("MainMenuItems", "Quit");
        _quit.GetControl.onClick.AddListener(delegate
        {
            Interface.QuitGame();
        });

        _langText.GetText.text = LangManager.Instance.Text("MainMenuItems", "Language");

        _langRu.GetText.text = LangManager.Instance.Text("MainMenuItems", "Russian");
        _langRu.GetControl.onClick.AddListener(delegate
        {
            ChangeLanguageOnRu();
        });

        _langEn.GetText.text = LangManager.Instance.Text("MainMenuItems", "English");

        _langEn.GetControl.onClick.AddListener(delegate
        {
            ChangeLanguageOnEn();
        });
    }

    #endregion


    #region Methods

    public override void Hide()
    {
        if (!IsShow)
        {
            return;
        }
        _mainPanel.gameObject.SetActive(false);
        IsShow = false;
    }

    public override void Show()
    {
        if (IsShow)
        {
            return;
        }
        _mainPanel.gameObject.SetActive(true);
        IsShow = true;
    }

    public void ShowOptions()
    {
        Interface.Execute(InterfaceObject.OptionsMenu);
    }

    public void LoadNewGameIndex(int csene)
    {
        SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
        Interface.LoadSceneAsync(csene);
    }

    private void LoadNewGame(string csene)
    {
        SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
        Interface.LoadSceneAsync(csene);
    }

    private void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        // init game
        SceneManager.sceneLoaded -= SceneManagerOnSceneLoaded;
    }

    private void ChangeLanguageOnRu()
    {
        LangManager.Instance.Init("Language", "Ru");
        ChangeLangMainMenu();
        _optionsMenu.ChangeLangOptionMenu();
    }

    private void ChangeLanguageOnEn()
    {
        LangManager.Instance.Init("Language", "En");
        ChangeLangMainMenu();
        _optionsMenu.ChangeLangOptionMenu();
    }

    private void ChangeLangMainMenu()
    {
        _newGame.GetText.text = LangManager.Instance.Text("MainMenuItems", "NewGame");
        _options.GetText.text = LangManager.Instance.Text("MainMenuItems", "Options");
        _quit.GetText.text = LangManager.Instance.Text("MainMenuItems", "Quit");
        _langText.GetText.text = LangManager.Instance.Text("MainMenuItems", "Language");
        _langRu.GetText.text = LangManager.Instance.Text("MainMenuItems", "Russian");
        _langEn.GetText.text = LangManager.Instance.Text("MainMenuItems", "English");
    }

    #endregion
}