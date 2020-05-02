using UnityEngine;


public abstract class BaseObjectScene : MonoBehaviour
{
    #region Fields

    private int _layer;

    #endregion


    #region Properties

    public Rigidbody Rigidbody { get; private set; }
    public Transform Transform { get; private set; }

    // Слой объекта
    public int Layer
    {
        get
        {
            //get => _layer;
            return _layer;
        }
        set
        {
            _layer = value;
            AskLayer(Transform, _layer);
        }
    }

    #endregion


    #region UnityMethods

    protected virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Transform = transform;
    }

    #endregion


    #region Methods

    // Выставляет слой себе и всем вложенным объектам независимо от уровня вложенности
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

    #endregion
}