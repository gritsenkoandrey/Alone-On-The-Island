using System;
using UnityEngine;


[Serializable]
public class CameraObject : MonoBehaviour
{
    public GameObject cam;
    [HideInInspector] public bool deleteQuestion = false;
    public KeyCode hotkey = KeyCode.None;
}
