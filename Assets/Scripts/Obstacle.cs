using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float DamageAmount;

    ObjectPool<Obstacle> _pool;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            var player = collision.collider.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(DamageAmount);
            }
        }
    }

    public void SetPool(ObjectPool<Obstacle> pool)
    {
        _pool = pool;
    }
    public void SelfDestruct()
    {
        _pool.Release(this);
    }
}
