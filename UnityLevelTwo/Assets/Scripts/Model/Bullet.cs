using UnityEngine;


public sealed class Bullet : Ammunition
{
    #region Fields

    private float _rayMaxDistance = 100.0f;
    private RaycastHit _hit;
    private ICollision _setDamage;

    #endregion


    #region UnityMethods

    private void OnCollisionEnter(Collision collision)
    {
        _setDamage = collision.gameObject.GetComponent<ICollision>();

        if (_setDamage != null)
        {
            _setDamage.CollisionEnter(new InfoCollision(_currentDamage, collision.contacts[0],
                collision.transform, Rigidbody.velocity));

            if (Physics.Raycast(gameObject.transform.position,
                gameObject.transform.forward, out _hit, _rayMaxDistance))
            {
                var particle = Instantiate(_particleSystem, _hit.point + _hit.normal, _hit.transform.rotation);
                //todo pool object
            }
        }
        DestroyAmmunition();
    }

    #endregion
}