using UnityEngine;


public abstract class Environment : BaseObjectScene, ICollision
{
    // todo manager
    [SerializeField] private BulletProjector _projector;

    public virtual void CollisionEnter(InfoCollision info)
    {
        if (_projector == null)
        {
            return;
        }

        var projectorRotation = Quaternion.FromToRotation(-Vector3.forward, info.Contact.normal);
        // manager
        var obj = Instantiate(_projector, info.Contact.point + info.Contact.normal * 0.25f,
            projectorRotation, info.ObjCollision);
        obj.transform.rotation = Quaternion.Euler(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y,
            Random.Range(0, 360));
    }
}