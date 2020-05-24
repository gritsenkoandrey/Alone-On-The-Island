using UnityEngine;


public sealed class Health : PickItems
{
    #region Fields

    [SerializeField] private float _health = 5.0f;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider obj)
    {
        _player = obj.GetComponent<Player>();

        if (_player)
        {
            _player.CurrentHealth += _health;
            _changeHealthUi.HealthTaken(_health);
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