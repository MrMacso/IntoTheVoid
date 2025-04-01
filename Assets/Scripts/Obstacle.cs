using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float _damageAmount;

    ObjectPool<Obstacle> _pool;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(_damageAmount);
            }
        }
    }
    public void SetDamageDeal(int amount)
    {
        _damageAmount = amount;
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
