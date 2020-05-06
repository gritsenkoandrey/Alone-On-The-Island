using UnityEngine;


public sealed class BulletRPG : AmmunitionRPG
{
    #region UnityMethods

    private void OnCollisionEnter(Collision collision)
    {
        var setDamage = collision.gameObject.GetComponent<ICollision>();
        if (setDamage != null)
        {
            setDamage.CollisionEnter(new InfoCollision(_currentDamage, Rigidbody.velocity));
        }
        //collision.collider.GetComponent<BaseObjectScene>().IsVisible = false;

        DestroyAmmunition();
    }

    #endregion
}