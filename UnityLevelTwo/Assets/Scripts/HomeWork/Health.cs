using UnityEngine;


public sealed class Health : PickItems
{
    #region Fields

    private readonly float _displayTime = 1.0f;

    private Player _player;
    private ChangeHealthUi _changeHealthUi;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider obj)
    {
        _player = obj.GetComponent<Player>();
        _changeHealthUi = Object.FindObjectOfType<ChangeHealthUi>();

        if (_player)
        {
            _player.CurrentHealth += health;
            _changeHealthUi.HealthTaken(health);
            _changeHealthUi.Invoke(nameof(_changeHealthUi.Clear), _displayTime);

            if (_player.CurrentHealth > _player.maxHealth)
            {
                _player.CurrentHealth = _player.maxHealth;
            }
            DestroyItem();
        }
    }

    #endregion
}