using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public sealed class Radar : BaseObjectScene
{
    #region Fields

    private Transform _playerPosition;
    private int _mapScale = 2;
    public static List<RadarObject> RadarObjects = new List<RadarObject>();

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        _playerPosition = Camera.main.transform;
        //_playerPosition = ServiceLocatorMonoBehaviour.GetService<CharacterController>().transform;
        //_playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    #endregion


    #region Methods

    public static void RegisterRadarObject(GameObject obj, Image img)
    {
        var image = Instantiate(img);
        RadarObjects.Add(new RadarObject { Owner = obj, Icon = image });
    }

    public static void RemoveRadarObject(GameObject obj)
    {
        var newList = new List<RadarObject>();
        foreach (var objects in RadarObjects)
        {
            if (objects.Owner == obj)
            {
                Destroy(objects.Icon);
                continue;
            }
            newList.Add(objects);
        }
        RadarObjects.RemoveRange(0, RadarObjects.Count);
        RadarObjects.AddRange(newList);
    }

    // Синхронизирует значки на миникарте с реальными объектами
    public void DrawRadarDots()
    {
        foreach (var obj in RadarObjects)
        {
            var radarPos = (obj.Owner.transform.position - _playerPosition.position);
            var distanceToObject =
                Vector3.Distance(_playerPosition.position, obj.Owner.transform.position) * _mapScale;
            var angle = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - _playerPosition.eulerAngles.y;
            radarPos.x = distanceToObject * Mathf.Cos(angle * Mathf.Deg2Rad) * -1;
            radarPos.z = distanceToObject * Mathf.Sin(angle * Mathf.Deg2Rad);
            obj.Icon.transform.SetParent(transform);
            obj.Icon.transform.position = new Vector3(radarPos.x, radarPos.z, 0) + transform.position;
        }
    }

    #endregion
}