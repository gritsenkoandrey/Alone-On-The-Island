using UnityEngine;
using UnityEngine.AI;


public class TestNavMesh : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform _targetFirst;
    [SerializeField] private Transform _targetSecond;

    private NavMeshPath _path;
    private float _elapsed = 0;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _path = new NavMeshPath();
        _elapsed = 0;
    }

    private void Update()
    {
        _elapsed += Time.deltaTime;
        if (_elapsed > 1)
        {
            _elapsed = -1;
            NavMesh.CalculatePath(_targetFirst.position, _targetSecond.position, NavMesh.AllAreas, _path);
        }
        for (var i = 0; i < _path.corners.Length - 1; i++)
        {
            Debug.DrawLine(_path.corners[i], _path.corners[i + 1], Color.yellow);
        }
    }

    #endregion
}