using UnityEngine;


public class InteractObject : BaseObjectScene
{
    #region Fields

    [SerializeField] private AudioClip[] _clip;
    private AudioSource _audio;
    private Player _player;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        _audio = GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        _player = other.GetComponent<Player>();

        if (_player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!_audio.isPlaying)
                {
                    _audio.PlayOneShot(_clip[Random.Range(0, _clip.Length)]);
                }
            }
        }
    }

    #endregion
}