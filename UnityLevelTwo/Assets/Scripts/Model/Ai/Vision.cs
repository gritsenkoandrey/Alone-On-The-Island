using UnityEngine;


[System.Serializable]
public sealed class Vision
{
    #region Fields

    public float ActiveDis = 35.0f; //10
    // угол обзора противника
    public float ActiveAng = 360.0f; //35

    #endregion


    #region Methods

    public bool VisionM(Transform player, Transform target)
    {
        return Distance(player, target) && Angle(player, target) && !CheckBlocked(player, target);
    }

    private bool CheckBlocked(Transform player, Transform target)
    {
        // Linecast создает линию между объектами и если нет преграды то true
        if (!Physics.Linecast(player.position, target.position, out var hit))
        {
            return true;
        }

        return hit.transform != target;
    }

    private bool Angle(Transform player, Transform target)
    {
        var angle = Vector3.Angle(target.position - player.position, player.forward);
        return angle <= ActiveAng;
    }

    private bool Distance(Transform player, Transform target)
    {
        return (player.position - target.position).sqrMagnitude <= ActiveDis * ActiveAng;
    }

    #endregion
}