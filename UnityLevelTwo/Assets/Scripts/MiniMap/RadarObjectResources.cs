using UnityEngine;
using UnityEngine.UI;


public sealed class RadarObjectResources : MonoBehaviour
{
    #region Fields

    [SerializeField] private Image _icon;

    #endregion


    #region UnityMethods

    private void OnValidate()
    {
        _icon = Resources.Load<Image>("Image");
    }

    private void OnDisable()
    {
        Radar.RemoveRadarObject(gameObject);
    }

    private void OnEnable()
    {
        Radar.RegisterRadarObject(gameObject, _icon);
    }

    #endregion
}