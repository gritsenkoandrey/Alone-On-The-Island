using UnityEngine;


public sealed class Bullet : Ammunition
{
    #region UnityMethods

    // todo своя обработка полета и получения урона
    private void OnCollisionEnter(Collision collision)
    {
        // дописать доп урон
        var setDamage = collision.gameObject.GetComponent<ICollision>();

        if (setDamage != null)
        {
            setDamage.CollisionEnter(new InfoCollision(_currentDamage, Rigidbody.velocity));
        }
        DestroyAmmunition();
    }

    #endregion
}