using UnityEngine;


public sealed class MineIModel : PickItems
{
    #region Field

    [SerializeField] private float _damage = 25.0f;

    #endregion


    #region MyRegion

    private void OnTriggerEnter(Collider obj)
    {
        _player = obj.GetComponent<Player>();

        if (_player)
        {
            _player.CurrentHealth -= _damage;
            _changeHealthUi.DamageTaken(_damage);
            _changeHealthUi.Invoke(nameof(_changeHealthUi.Clear), _displayTime);

            if (_player.CurrentHealth < _player.minHealth)
            {
                _player.CurrentHealth = _player.minHealth;
            }

            DestroyItem();
        }
    }

    #endregion
}