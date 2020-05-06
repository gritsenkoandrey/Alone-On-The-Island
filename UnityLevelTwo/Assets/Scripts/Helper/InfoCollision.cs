using UnityEngine;


public readonly struct InfoCollision
{
    #region Fields

    private readonly Vector3 _direction;
    private readonly float _damage;

    #endregion


    #region Properties

    public Vector3 Direction
    {
        get { return _direction; }
    }

    public float Damage
    {
        get { return _damage; }
    }

    #endregion


    #region ClassLifeCycless

    public InfoCollision(float damage, Vector3 direction = default)
    {
        _damage = damage;
        _direction = direction;
    }

    #endregion
}