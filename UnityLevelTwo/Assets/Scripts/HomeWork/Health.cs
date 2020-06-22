using UnityEngine;


public sealed class Health : PickItems
{
    #region Fields

    [SerializeField] private float _health = 5.0f;
    [SerializeField] private AudioClip[] _audioClips;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider obj)
    {
        _player = obj.GetComponent<Player>();
        _audioSource = obj.GetComponent<AudioSource>();

        if (_player)
        {
            _player.CurrentHealth += _health;
            _changeHealthUi.HealthTaken(_health);
            _changeHealthUi.Invoke(nameof(_changeHealthUi.Clear), _displayTime);

            if (_player.CurrentHealth > _player.maxHealth)
            {
                _player.CurrentHealth = _player.maxHealth;
            }
            ExplosionSound();
            DestroyItem();
        }
    }

    #endregion


    #region Methods

    public override void ExplosionSound()
    {
        _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);
    }

    #endregion
}