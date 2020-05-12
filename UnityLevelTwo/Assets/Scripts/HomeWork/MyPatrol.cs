using UnityEngine;


public class MyPatrol : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    private float _obstacleRange = 2.0f;
    private bool _isAlive;

    private void Start()
    {
        _isAlive = true;
    }

    private void Update()
    {
        if (_isAlive)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
        }
        var ray = new Ray(transform.position, transform.forward);
        if (Physics.SphereCast(ray, 1.0f, out var hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hit.distance < _obstacleRange)
            {
                float angle = Random.Range(-120, 120);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}