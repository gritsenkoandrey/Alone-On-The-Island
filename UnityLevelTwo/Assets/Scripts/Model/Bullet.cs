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
            setDamage.CollisionEnter(new InfoCollision(_currentDamage, collision.contacts[0],
                collision.transform, Rigidbody.velocity));

            // наработка для уменьшающего луча
            //if (!TryGetComponent<Transform>(out _))
            //{
            //    collision.gameObject.AddComponent<Transform>();
            //}
            //collision.gameObject.transform.localScale -= new Vector3(0.1f, 0.1f, 0);


            //todo место попадания пули
            Instantiate(_particleSystem, collision.transform.position, collision.transform.rotation);
        }
        DestroyAmmunition();
    }

    #endregion
}