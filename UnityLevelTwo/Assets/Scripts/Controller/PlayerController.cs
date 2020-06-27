using UnityEngine;


public sealed class PlayerController : BaseController, IExecute, IInitialization
{
    #region Fields

    private readonly IMotor _motor;
    private Player _player;
    private GameOverUi _gameOver;

    #endregion


    #region ClassLifeCycles

    public PlayerController(IMotor motor/*, Player player*/)
    {
        _motor = motor;
        //_player = player;
    }

    #endregion


    #region Methods

    public void Initialization()
    {
        _player = Object.FindObjectOfType<Player>();
        _gameOver = Object.FindObjectOfType<GameOverUi>();
        UiInterface.PlayerUiBar.SetActive(true);
        UiInterface.PlayerUiText.SetActive(true);
        UiInterface.PlayerUiBar.SetColor(Color.green);
    }

    public void Execute()
    {
        if (!IsActive)
        {
            return;
        }

        _motor.Move();
        _player.FootSteps();
        _player.JumpSound();

        UiInterface.PlayerUiBar.Fill = _player.FillHealth;
        UiInterface.PlayerUiText.Text = _player.PercentHealth;

        if (_player.CurrentHealth < _player.AverageHealth)
        {
            UiInterface.PlayerUiBar.SetColor(Color.red);
        }

        if (_player.CurrentHealth <= 0)
        {
            _gameOver.Invoke(nameof(_gameOver.GameOver), 2);
            //_gameOver.GameOver();
            Off();
        }
    }

    #endregion
}