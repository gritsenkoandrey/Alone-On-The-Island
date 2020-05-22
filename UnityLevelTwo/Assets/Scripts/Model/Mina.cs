using System.Collections;
using UnityEngine;


public class Mina : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private GameObject _light;
    private Collider[] _objects;
    private int _timeLight;
    private readonly int _maxArray = 100;

    private void Start()
    {
        _light.GetComponent<Light>().color = Color.red;
        StartCoroutine(Light());
        _timeLight = 1;

        _objects = new Collider[_maxArray];
        Physics.OverlapSphereNonAlloc(transform.position, _radius, _objects);
        Explosion(_objects);

        //var col = Physics.OverlapSphere(transform.position, _radius);
        //Explosion(col);

        //StartCoroutine(Explosion);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    //var hitColliders = Physics.OverlapSphere(transform.position, _radius);
    //    //Explosion(hitColliders);
    //}

    private void Explosion(Collider[] array)
    {
        for (var i = 0; i <= array.Length - 1; i++)
        {
            var obj = array[i];
            var isComponent = obj.TryGetComponent<Rigidbody>(out _);
            if (isComponent)
            {
                var body = obj.GetComponent<Rigidbody>();
                body.useGravity = true;
                body.isKinematic = false;
                body.AddExplosionForce(_force, transform.position, _radius);
            }
            else
            {
                Debug.Log(obj);
            }
        }
        //    //var tempObj = obj.GetComponent<ISetDamage>();
        //    //if (tempObj == null) continue;
        //    //obj.GetComponent<ISetDamage>().ApplyDamage(1000);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    _timeLight = 1;
    //}

    //private void OnTriggerEnter(Collider collider)
    //{
    //    _timeLight = 2;
    //}

    private IEnumerator Light()
    {
        while (true)
        {
            _light.SetActive(!_light.activeSelf);
            yield return new WaitForSeconds(_timeLight);
        }
    }

    //IEnumerator Explosion()
    //{
    //    Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius);
    //    yield return new WaitForSeconds(2);
    //    Explosion(hitColliders);
    //    yield return new WaitForSeconds(0.5f);
    //    Explosion(hitColliders);
    //}
}