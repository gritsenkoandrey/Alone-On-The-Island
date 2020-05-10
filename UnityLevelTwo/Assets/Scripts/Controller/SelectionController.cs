using System;
using UnityEngine;
//using UnityEngine.UI;


// ответственность данного класса - это выделить объект
public sealed class SelectionController : BaseController, IExecute
{
    #region Fields

    private readonly Camera _mainCamera;
    // выделенный объект
    private GameObject _dedicateObj;

    private readonly Vector2 _center;

    // дистанция на которую будет бить луч
    private readonly float _dedicateDistance = 20.0f;
    private bool _nullString;
    private bool _isSelectedObj = false;

    // выбранный объект
    private ISelectObj _selectedObj;
    private ISelectObjImage _selectedObjImage;

    #endregion


    #region ClassLifeCycles

    public SelectionController()
    {
        _mainCamera = Camera.main;
        _center = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
    }

    #endregion


    #region Methods

    public void Execute()
    {

        if (!IsActive)
        {
            return;
        }

        // если луч попал в объект, то вызывается метод SelectObject()
        if (Physics.Raycast(_mainCamera.ScreenPointToRay(_center), out var hit, _dedicateDistance))
        {
            SelectObject(hit.collider.gameObject);
            _nullString = false;
        }
        // если UI не обновлена, то обновляю ее
        else if (!_nullString)
        {
            UiInterface.SelectionObjMessageUi.Text = String.Empty;
            UiInterface.SelectionObjMessageUiImage.Fill = Single.NaN;

            _nullString = true;
            _dedicateObj = null;
            _isSelectedObj = false;
        }

        //if (_isSelectedObj)
        //{
        //    // действие над объектом
        //    switch (_selectedObj)
        //    {
        //        case Weapon aim:
        //            // в инвентарь
        //            // Inventory.AddWeapon(aim);
        //            break;
        //        case Wall wall:
        //            break;
        //    }
        //}
    }

    private void SelectObject(GameObject obj)
    {
        // если данный объект совпадает с предыдущим выделенным объектом, то мы его повторно не выделяем
        //if (obj == _dedicateObj)
        //{
        //    return;
        //}

        // если мы его не выделяли, то записываем в нужный интерфейс
        _selectedObj = obj.GetComponent<ISelectObj>();
        _selectedObjImage = obj.GetComponent<ISelectObjImage>();

        if (_selectedObj != null && _selectedObjImage != null)
        {
            UiInterface.SelectionObjMessageUi.Text = _selectedObj.GetMessage();
            UiInterface.SelectionObjMessageUiImage.Fill = _selectedObjImage.GetImage();
            UiInterface.SelectionObjMessageUiImage.SetColor(Color.green);

            _isSelectedObj = true;
        }
        else
        {
            UiInterface.SelectionObjMessageUi.Text = String.Empty;
            UiInterface.SelectionObjMessageUiImage.Fill = Single.NaN;
            _isSelectedObj = false;
        }
        _dedicateObj = obj;
    }

    #endregion
}