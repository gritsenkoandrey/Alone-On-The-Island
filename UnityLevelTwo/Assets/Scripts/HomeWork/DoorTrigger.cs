using UnityEngine;


public sealed class DoorTrigger : Door
{
    private Door _door;

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
}