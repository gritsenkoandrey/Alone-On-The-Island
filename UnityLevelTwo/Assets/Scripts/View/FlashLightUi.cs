using UnityEngine;
using UnityEngine.UI;


public sealed class FlashLightUi : MonoBehaviour
{
    private Text _text;
    //todo image

    public float Text
    {
        //set => _text.text = $"{value:0.0}";
        set
        {
            _text.text = $"{value:0.0}";
        }
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void SetActive(bool value)
    {
        _text.gameObject.SetActive(value);
    }
}