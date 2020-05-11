using UnityEngine;


public readonly struct InfoCollision
{
    #region Fields

    private readonly Vector3 _direction;
    private readonly float _damage;
    private readonly ContactPoint _contact;
    private readonly Transform _objCollision;

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

    public ContactPoint Contact
    {
        get { return _contact; }
    }

    public Transform ObjCollision
    {
        get { return _objCollision; }
    }

    #endregion


    #region ClassLifeCycless

    public InfoCollision(float damage, ContactPoint contact, Transform objCollision, Vector3 direction = default)
    {
        _damage = damage;
        _contact = contact;
        _objCollision = objCollision;
        _direction = direction;
    }

    #endregion
}