using UnityEngine;


public sealed class DoorTrigger : Door
{
    #region Fields

    private CharacterController _character;

    #endregion


    #region UnityMethods

    private void OnTriggerEnter(Collider collider)
    {
        _character = collider.GetComponent<CharacterController>();
        if (_character)
        {
            Activate();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        _character = collider.GetComponent<CharacterController>();
        if (_character)
        {
            Deactivate();
        }
    }

    #endregion
}