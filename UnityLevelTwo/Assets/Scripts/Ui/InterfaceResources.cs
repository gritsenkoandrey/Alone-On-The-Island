using UnityEngine;
using UnityEngine.UI;


public sealed class InterfaceResources : MonoBehaviour
{
    #region Fields

    public ButtonUi ButtonPrefab { get; private set; }
    public Canvas MainCanvas { get; private set; }
    public SliderUi ProgressBarPrefab { get; private set; }

    #endregion


    #region UnityMethods

    private void Awake()
    {
        ButtonPrefab = Resources.Load<ButtonUi>("Button");
        MainCanvas = FindObjectOfType<Canvas>();
        ProgressBarPrefab = Resources.Load<SliderUi>("ProgressBar");
    }

    #endregion
}