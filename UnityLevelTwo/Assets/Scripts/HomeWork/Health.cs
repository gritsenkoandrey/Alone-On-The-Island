using UnityEngine;


public sealed class Health : PickItems
{
    #region UnityMethods

    private void OnTriggerEnter(Collider obj)
    {
        var player = obj.GetComponent<Player>();
        if (player)
        {
            player.CurrentHealth += health;
            if (player.CurrentHealth > player._maxHealth)
            {
                player.CurrentHealth = player._maxHealth;
            }
            //Debug.Log(health);
            DestroyItem();
        }
    }

    #endregion
}