using UnityEngine;
using UnityEngine.AI;


public sealed class CreateRandomPoint : BaseObjectScene
{
    #region Fields

    public int count = 10;
    public float offset = 1;
    public string name = "Object";
    private float _minDistance = 5.0f;
    private float _maxDistance = 125.0f;
    public GameObject gameObj;
    private Transform _root;

    #endregion


    #region Methods

    public void CreateObject()
    {
        _root = new GameObject(name).transform;

        for (var i = 1; i <= count; i++)
        {
            var dis = Random.Range(_minDistance, _maxDistance);
            var randomPoint = Random.insideUnitSphere * dis;
            NavMesh.SamplePosition(randomPoint, out var hit, dis, NavMesh.AllAreas);
            var result = hit.position;
            result.y += offset;
            Instantiate(gameObj, result, Quaternion.identity, _root);
        }
    }

    #endregion
}