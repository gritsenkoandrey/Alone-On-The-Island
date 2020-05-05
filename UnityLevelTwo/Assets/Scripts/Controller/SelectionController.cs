using System;
using UnityEngine;


// ответственность данного класса - это выделить объект
public sealed class SelectionController : BaseController, IExecute
{
    private readonly Camera _mainCamera;
    private readonly Vector2 _center;
    // дистанция на которую будет бить луч
    private readonly float _dedicateDistance = 20.0f;
    // выделенный объект
    private GameObject _dedicateObj;
    // выбранный объект
    private ISelectObj _selectedObj;
    private bool _nullString;
    private bool _isSelectedObj;

    public SelectionController()
    {
        _mainCamera = Camera.main;
        _center = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
    }

    public void Execute()
    {
        if (!IsActive)
        {
            return;
        }

        if (Physics.Raycast(_mainCamera.ScreenPointToRay(_center), out var hit, _dedicateDistance))
        {
            SelectObject(hit.collider.gameObject);
            _nullString = false;
        }
        // если UI не обновлена, то обновляю ее
        else if (!_nullString)
        {
            UiInterface.SelectionObjMessageUi.Text = String.Empty;
            _nullString = true;
            _dedicateObj = null;
            _isSelectedObj = false;
        }

        if (_isSelectedObj)
        {
            // действие над объектом


            switch (_selectedObj)
            {
                case Weapon aim:
                    // в инвентарь

                    // Inventory.AddWeapon(aim);
                    break;
                case Wall wall:
                    break;
            }
        }
    }

    private void SelectObject(GameObject obj)
    {
        // если данный объект совпадает с предыдущим выделенным объектом, то мы его повторно не выделяем
        if (obj == _dedicateObj)
        {
            return;
        }
        // если мы его не выделяли, то записываем в нужный интерфейс
        _selectedObj = obj.GetComponent<ISelectObj>();

        if (_selectedObj != null)
        {
            UiInterface.SelectionObjMessageUi.Text = _selectedObj.GetMessage();
            _isSelectedObj = true;
        }
        else
        {
            UiInterface.SelectionObjMessageUi.Text = String.Empty;
            _isSelectedObj = false;
        }
        _dedicateObj = obj;
    }
}