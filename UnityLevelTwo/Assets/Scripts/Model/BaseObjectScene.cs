using UnityEngine;


public abstract class BaseObjectScene : MonoBehaviour
{
    private int _layer; 

    public Rigidbody Rigidbody { get; private set; }
    public Transform Transform { get; private set; }
    public int Layer
    {
        get
        {
            return _layer; // get => _layer;
        }
        set
        {
            _layer = value;
            AskLayer(Transform, _layer);
        }
    }

    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Transform = transform;
    }

    private void AskLayer (Transform obj, int layer)
    {
        obj.gameObject.layer = layer;
        if (obj.childCount <= 0)
        {
            return;
        }

        foreach (Transform child in obj)
        {
            AskLayer(child, layer);
        }
    }
}