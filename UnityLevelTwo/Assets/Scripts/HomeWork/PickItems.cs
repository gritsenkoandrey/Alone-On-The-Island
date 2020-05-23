using UnityEngine;


public abstract class PickItems : BaseObjectScene, ISelectObj, ISelectObjImage
{
    #region Fields

    [SerializeField] private float _baseHealth = 5.0f;
    [SerializeField] private float _timeToDestruct = 0;
    protected float health;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        health = _baseHealth;
    }

    #endregion


    #region Methods

    public void DestroyItem()
    {
        Destroy(gameObject, _timeToDestruct);
    }

    #endregion

    public string GetMessage()
    {
        return Name;
    }

    public float GetImage()
    {
        return default;
    }
}