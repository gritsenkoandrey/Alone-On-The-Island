using UnityEngine;
using UnityEngine.UI;


public sealed class AimUiText : MonoBehaviour
{
    #region Fields

    private Aim[] _aims;
    private TargetSphere[] _sphere;
    private Wall[] _wall;
    private Text _text;

    private int _countPoint;

    #endregion


    #region UnityMethods

    private void Awake()
    {
        _aims = FindObjectsOfType<Aim>();
        _sphere = FindObjectsOfType<TargetSphere>();
        _wall = FindObjectsOfType<Wall>();
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        foreach (var aim in _aims)
        {
            aim.OnPointChange += UpdatePoint;
        }

        foreach (var sphere in _sphere)
        {
            sphere.OnPointChange += UpdatePoint;
        }

        foreach (var wall in _wall)
        {
            wall.OnPointChange += UpdatePoint;
        }
    }

    private void OnDisable()
    {
        foreach (var aim in _aims)
        {
            aim.OnPointChange -= UpdatePoint;
        }

        foreach (var sphere in _sphere)
        {
            sphere.OnPointChange -= UpdatePoint;
        }

        foreach (var wall in _wall)
        {
            wall.OnPointChange -= UpdatePoint;
        }
    }

    #endregion


    #region Methods

    private void UpdatePoint()
    {
        var pointText = "очков";
        ++_countPoint;
        if (_countPoint >= 5)
        {
            pointText = "очков";
        }
        else if(_countPoint == 1)
        {
            pointText = "очко";
        }
        else if(_countPoint < 5)
        {
            pointText = "очка";
        }
        _text.text = $"Вы заработали {_countPoint} {pointText}";

        // todo отписаться удалить из списка
    }

    #endregion
}