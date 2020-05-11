using UnityEngine;


public abstract class Door : BaseObjectScene, ISelectObj, ISelectObjImage
{
    #region Fields

    [SerializeField] private Vector3 _doorPosition;
    private Vector3 _pos;

    private bool _isOpen = false;

    #endregion


    #region Methods

    //public void Operate()
    //{
    //    if (_isOpen)
    //    {
    //        _pos = transform.position - _doorPosition;
    //        transform.position = _pos;
    //    }

    //    if (!_isOpen)
    //    {
    //        _pos = transform.position + _doorPosition;
    //        transform.position = _pos;
    //    }

    //    _isOpen = !_isOpen;
    //}

    public void Activate()
    {
        if (!_isOpen)
        {
            _pos = transform.position + _doorPosition;
            transform.position = _pos;
            _isOpen = true;
        }
    }

    public void Deactivate()
    {
        if (_isOpen)
        {
            _pos = transform.position - _doorPosition;
            transform.position = _pos;
            _isOpen = false;
        }
    }

    public string GetMessage()
    {
        return Name;
    }

    public float GetImage()
    {
        return default;
    }

    #endregion
}