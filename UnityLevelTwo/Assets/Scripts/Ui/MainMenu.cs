using UnityEngine;
using UnityEngine.SceneManagement;


public sealed class MainMenu : BaseMenu
{
    [SerializeField] private GameObject _mainPanel;

    [SerializeField] private ButtonUi _newGame;
    [SerializeField] private ButtonUi _options;
    [SerializeField] private ButtonUi _quit;

    private void Start()
    {
        _newGame.GetText.text = LangManager.Instance.Text("MainMenuItems", "NewGame");
        _newGame.GetControl.onClick.AddListener(delegate
        {
            LoadNewGame(SceneManagerHelper.Instance.Scenes.Game.SceneAsset.name);
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
    }

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
}