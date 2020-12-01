using UnityEngine;


public sealed class TestCharacterVisibility : MonoBehaviour
{
    #region Fields

    [SerializeField] private float _activeDis;
    [SerializeField] private bool _isAllowScaling;

    #endregion


    #region UnityMethods
    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "bot.jpg", _isAllowScaling);
    }

    private void OnDrawGizmosSelected()
    {
        Transform t = transform;

        //Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

        var flat = new Vector3(_activeDis, 0, _activeDis);
        Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
        Gizmos.DrawWireSphere(Vector3.zero, 5);
    }
    #endif
    #endregion
}