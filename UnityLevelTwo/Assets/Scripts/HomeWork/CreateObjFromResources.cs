using UnityEngine;
using UnityEngine.AI;


public class CreateObjFromResources : MonoBehaviour
{
    #region Fields

    public int count = 10;
    public float offset = 1;
    public string name = "Object";
    private float _minDistance = 5.0f;
    private float _maxDistance = 125.0f;
    private GameObject _gameObject;
    private Transform _root;

    #endregion

    private void Start()
    {
        _gameObject = Resources.Load<GameObject>("Health");
        CreateObject();
    }

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
            Instantiate(_gameObject, result, Quaternion.identity, _root);
        }
    }

    #endregion

}