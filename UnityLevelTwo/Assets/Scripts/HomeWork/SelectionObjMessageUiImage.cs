using UnityEngine;
using UnityEngine.UI;


public sealed class SelectionObjMessageUiImage : MonoBehaviour
{
    private Image _image;

    public float Fill
    {
        set { _image.fillAmount = value; }
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void SetActive(bool value)
    {
        _image.gameObject.SetActive(value);
    }

    public void SetColor(Color value)
    {
        _image.color = value;
    }
}