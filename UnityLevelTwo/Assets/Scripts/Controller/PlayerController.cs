using UnityEngine;


public sealed class PlayerController : BaseController, IExecute, IInitialization
{
    #region Fields

    private readonly IMotor _motor;
    private Player _player;

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
        On();
    }

    public void Execute()
    {
        if (!IsActive)
        {
            return;
        }

        _motor.Move();

        UiInterface.PlayerUiBar.Fill = _player.FillHealth;
        UiInterface.PlayerUiText.Text = _player.PercentHealth;

        if (_player.CurrentHealth < _player.AverageHealth)
        {
            UiInterface.PlayerUiBar.SetColor(Color.red);
        }

        else if (_player.CurrentHealth <= 0)
        {
            Off();
        }
    }
    public override void On()
    {
        if (IsActive)
        {
            return;
        }

        base.On();

        UiInterface.PlayerUiBar.SetActive(true);
        UiInterface.PlayerUiText.SetActive(true);
        UiInterface.PlayerUiBar.SetColor(Color.green);
    }

    public override void Off()
    {
        if (!IsActive)
        {
            return;
        }

        base.Off();

        UiInterface.PlayerUiBar.SetActive(false);
        UiInterface.PlayerUiText.SetActive(false);
    }

    #endregion
}