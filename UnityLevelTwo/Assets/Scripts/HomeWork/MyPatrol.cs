using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class MyPatrol : BaseObjectScene
{
    #region Fields

    [SerializeField] private float _speed = 10.0f;
    [SerializeField] private float _obstacleRange = 5.0f;
    private float _radius = 0.75f;
    private float _angle;

    private bool _isActive;

    #endregion


    #region UnityMethods

    protected override void Awake()
    {
        _isActive = true;
    }

    private void Update()
    {
        if (_isActive)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
            var ray = new Ray(transform.position, transform.forward);
            if (Physics.SphereCast(ray, _radius, out var hit))
            {
                var hitObject = hit.transform.gameObject;
                if (hit.distance < _obstacleRange)
                {
                    _angle = Random.Range(-180, 180);
                    transform.Rotate(0, _angle, 0);
                }
            }
        }
    }

    #endregion
}