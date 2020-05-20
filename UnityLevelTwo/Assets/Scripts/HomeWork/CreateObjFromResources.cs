using UnityEngine;
using UnityEngine.AI;


public sealed class CreateObjFromResources : BaseObjectScene
{
    #region Fields

    private int _count = 10;
    private float _offset = 2;
    private float _minDistance = 5.0f;
    private float _maxDistance = 125.0f;
    private string name = "Object";
    private GameObject _gameObject;
    private Transform _root;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        base.Awake();
        _gameObject = Resources.Load<GameObject>("Health");
    }

    #endregion


    #region Methods

    public void CreateObject()
    {
        _root = new GameObject(name).transform;

        for (var i = 1; i <= _count; i++)
        {
            var dis = Random.Range(_minDistance, _maxDistance);
            var randomPoint = Random.insideUnitSphere * dis;
            NavMesh.SamplePosition(randomPoint, out var hit, dis, NavMesh.AllAreas);
            var result = hit.position;
            result.y += _offset;
            Instantiate(_gameObject, result, Quaternion.identity, _root);
        }
    }

    #endregion
}