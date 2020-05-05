using UnityEngine;


public abstract class BaseObjectScene : MonoBehaviour
{
    #region Fields

    private Color _color;

    private int _layer;

    private bool _isVisible;

    [HideInInspector] public Rigidbody Rigidbody;
    [HideInInspector] public Transform Transform;

    #endregion


    #region Properties

    //public Rigidbody Rigidbody { get; private set; }
    //public Transform Transform { get; private set; }

    // слой объекта
    public int Layer
    {
        get { return _layer; }
        set
        {
            _layer = value;
            AskLayer(transform, _layer);
        }
    }

    // имя объекта
    public string Name
    {
        get { return gameObject.name; }
        set { gameObject.name = value; }
    }

    // цвет материала объекта
    public Color Color
    {
        get { return _color; }
        set
        {
            _color = value;
            AskColor(transform, _color);
        }
    }

    // выключится рендер у нашего объекта
    public bool IsVisible
    {
        get { return _isVisible; }
        set
        {
            _isVisible = value;
            RendererSetActive(transform);
            if (transform.childCount <= 0)
            {
                return;
            }
            foreach (Transform t in transform)
            {
                RendererSetActive(t);
            }
        }
    }

    #endregion


    #region UnityMethods

    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Transform = GetComponent<Transform>();
    }

    #endregion


    #region Methods

    // Выставляет слой себе и всем вложенным объектам независимо от уровня вложенности
    // obj = объект, layer = слой
    private void AskLayer (Transform obj, int layer)
    {
        // Выставляем объекту слой
        obj.gameObject.layer = layer;
        if (obj.childCount <= 0)
        {
            return;
        }
        // Проходит по всем вложенным объектам
        foreach (Transform child in obj)
        {
            // Рекурсивный вызов функции
            AskLayer(child, layer);
        }
    }

    private void RendererSetActive(Transform renderer)
    {
        if (renderer.gameObject.TryGetComponent<Renderer>(out var component))
        {
            component.enabled = _isVisible;
        }
    }

    private void AskColor(Transform obj, Color color)
    {
        foreach (var currentMaterial in obj.GetComponent<Renderer>().materials)
        {
            currentMaterial.color = color;
        }
        if (obj.childCount <= 0)
        {
            return;
        }
        foreach (Transform d in obj)
        {
            AskColor(d, color);
        }
    }

    // выключаем физику у объекта и его детей
    public void DisableRigidbody()
    {
        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var body in rigidbodies)
        {
            body.isKinematic = true;
        }
    }

    // включаем физику у объекта и его детей
    public void EnableRigidbody(float force)
    {
        EnableRigidbody();
        Rigidbody.AddForce(transform.forward * force);
    }

    // включаем физику у объекта и его детей
    public void EnableRigidbody()
    {
        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var body in rigidbodies)
        {
            body.isKinematic = false;
        }
    }

    // Замораживает или размораживает физическую трансформацию объекта
    // "rigidbodyConstraints" - Трансформацию которую нужно заморозить
    public void ConstraintsrigidBody(RigidbodyConstraints rigidbodyConstraints)
    {
        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var body in rigidbodies)
        {
            body.constraints = rigidbodyConstraints;
        }
    }

    public void SetActive(bool value)
    {
        IsVisible = value;
        if (TryGetComponent<Collider>(out var component))
        {
            component.enabled = value;
        }
    }

    #endregion
}