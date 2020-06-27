using UnityEngine;


public sealed class MineIModel : PickItems
{
    #region Fields

    [SerializeField] private float _damage = 25.0f;
    [SerializeField] private ParticleSystem _particleExplosion;
    [SerializeField] private AudioClip[] _audioClips;
    private ShakeMainCamera _shakeCamera;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider obj)
    {
        _player = obj.GetComponent<Player>();
        _bot = obj.GetComponent<Bot>();
        _audioSource = obj.GetComponent<AudioSource>();
        _shakeCamera = Camera.main.GetComponent<ShakeMainCamera>();
        if (_player)
        {
            _player.CurrentHealth -= _damage;
            _changeHealthUi.DamageTaken(_damage);
            _changeHealthUi.Invoke(nameof(_changeHealthUi.Clear), _displayTime);
            if (_player.CurrentHealth < _player.minHealth)
            {
                _player.CurrentHealth = _player.minHealth;
            }
            ExplosionSound();
            _shakeCamera.ShakeCamera();
            DestroyItem();
            Instantiate(_particleExplosion, transform.position, transform.rotation);
            
        }

        if (_bot)
        {
            _bot.CurrentHealth -= _damage;
            if (_bot.CurrentHealth <= 0)
            {
                _bot.DyingBot();
                //_bot.DieRagdoll();
            }
            DestroyItem();
            Instantiate(_particleExplosion, transform.position, transform.rotation);
            ExplosionSound();
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