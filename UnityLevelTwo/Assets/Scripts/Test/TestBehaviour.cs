using UnityEngine;
using UnityEngine.AI;


public sealed class TestBehaviour : MonoBehaviour
{
    public int count = 10;
    public int offset = 1;
    public GameObject obj;

    public float Test;
    private Transform _root;

    private void Awake()
    {
        Debug.Log(47);
    }

    private void Start()
    {
        CreateObj();
    }

    public void CreateObj()
    {
        _root = new GameObject("Root").transform;
        for (var i = 1; i <= count; i++)
        {
            Instantiate(obj, new Vector3(0, offset * i, 0), Quaternion.identity, _root);
            //todo Свой алгоритм по расстановке мин или аптечек

            //var dis = Random.Range(25, 125);
            //var randomPoint = Random.insideUnitSphere * dis;
            //NavMesh.SamplePosition(randomPoint, out var hit, dis, NavMesh.AllAreas);
            //var result = hit.position;
            //Instantiate(obj, result, Quaternion.identity, _root);
        }
    }

    public void AddComponent()
    {
        gameObject.AddComponent<Rigidbody>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.AddComponent<BoxCollider>();
    }

    public void RemoveComponent()
    {
        DestroyImmediate(GetComponent<Rigidbody>());
        DestroyImmediate(GetComponent<MeshRenderer>());
        DestroyImmediate(GetComponent<BoxCollider>());
    }

    private void OnGUI()
    {
        GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 20), "Click Me");
    }
}