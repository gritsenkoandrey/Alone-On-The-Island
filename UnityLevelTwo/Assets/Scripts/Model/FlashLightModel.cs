using System;
using UnityEngine;


public sealed class FlashLightModel : BaseObjectScene
{
    #region Fields

    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _batteryChargeMax = 10.0f;

    private Light _light;
    private Transform _goFollow;

    private Vector3 _vecOffset;

    #endregion


    #region Properties

    public float BatteryChargeCurrent { get; private set; }

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();

        _light = GetComponent<Light>();
        _goFollow = Camera.main.transform;
        _vecOffset = Transform.position - _goFollow.position;
        BatteryChargeCurrent = _batteryChargeMax;

        // turn off the light when the game starts
        //_light.enabled = false;
    }

    #endregion


    #region Methods

    public void Switch(FlashLightActiveType value)
    {
        switch (value)
        {
            case FlashLightActiveType.On:
                _light.enabled = true;
                Transform.position = _goFollow.position + _vecOffset;
                Transform.rotation = _goFollow.rotation;
                break;
            case FlashLightActiveType.Off:
                _light.enabled = false;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value, null);
        }
    }

    public void Rotation()
    {
        Transform.position = _goFollow.position + _vecOffset;
        Transform.rotation = Quaternion.Lerp(Transform.rotation, _goFollow.rotation, _speed * Time.deltaTime);
    }

    public bool EditBatteryCharge()
    {
        if (BatteryChargeCurrent > 0)
        {
            BatteryChargeCurrent -= Time.deltaTime;
            return true;
        }
        return false;
    }

    public bool AddBatteryCharge()
    {
        if (BatteryChargeCurrent < _batteryChargeMax)
        {
            BatteryChargeCurrent += Time.deltaTime;
            return true;
        }
        return false;
    }

    #endregion
}