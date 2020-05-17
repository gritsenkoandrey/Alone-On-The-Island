using UnityEngine;


public sealed class TestBehaviour : MonoBehaviour
{
    #region Fields

    public int count = 10;
    public int offset = 1;
    public GameObject obj;

    public float Test;
    private Transform _root;

    #endregion


    #region UnityMethods

    private void Awake()
    {
        Debug.Log(47);
    }

    private void Start()
    {
        CreateObj();
    }

    private void OnGUI()
    {
        GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 20), "Click Me");
    }

    #endregion


    #region Methods

    public void CreateObj()
    {
        _root = new GameObject("Root").transform;
        for (var i = 1; i <= count; i++)
        {
            Instantiate(obj, new Vector3(0, offset * i, 0), Quaternion.identity, _root);
            //todo Свой алгоритм по расстановке мин или аптечек
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

    #endregion
}