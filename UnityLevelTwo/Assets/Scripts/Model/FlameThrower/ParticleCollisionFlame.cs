using System;
using UnityEngine;


// обработка столкновения частиц
public class ParticleCollisionFlame : MonoBehaviour
{
    public event Action<GameObject> Message;

    private void OnParticleCollision(GameObject other)
    {
        Message?.Invoke(other);
    }
}