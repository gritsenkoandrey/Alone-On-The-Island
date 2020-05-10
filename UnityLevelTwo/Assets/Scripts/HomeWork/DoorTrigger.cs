using UnityEngine;


public sealed class DoorTrigger : Door
{
    #region Fields

    private Door _door;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _door = FindObjectOfType<Door>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        _door.Activate();
    }

    private void OnTriggerExit(Collider collider)
    {
        _door.Deactivate();
    }


    #endregion
}