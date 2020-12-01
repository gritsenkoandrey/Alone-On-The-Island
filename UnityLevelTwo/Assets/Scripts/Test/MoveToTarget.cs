using UnityEngine;
using UnityEngine.AI;


public class MoveToTarget : MonoBehaviour
{
    #region Fields

    [SerializeField] private Transform _target;

    #endregion


    #region Properties

    public NavMeshAgent Agent { get; private set; }

    #endregion


    #region UnityMethods

    private void Start()
    {
        Agent = GetComponentInChildren<NavMeshAgent>();
    }

    private void Update()
    {
        if (_target != null)
        {
            Agent.SetDestination(_target.position);
        }
    }

    #endregion
}