using System;
using UnityEngine;


public sealed class CreateWayPoint : MonoBehaviour
{
    #region Fields

    //работает только при активированном Gizmos
    [SerializeField] private TargetPoint _prefab;
    private PathBot _rootWayPoint;

    #endregion


    #region Methods

    public void InstantiateObj(Vector3 pos)
    {
        if (!_rootWayPoint)
        {
            _rootWayPoint = new GameObject("WayPoint").AddComponent<PathBot>();
        }

        if (_prefab != null)
        {
            Instantiate(_prefab, pos, Quaternion.identity, _rootWayPoint.transform);
        }
        else
        {
            throw new Exception($"Нет префаба на компоненте {typeof(CreateWayPoint)} {gameObject.name}");
        }
    }

    #endregion
}