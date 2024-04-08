using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TunnelPiece : MonoBehaviour
{
    [SerializeField] float _speed = 8.0f;
    [SerializeField] float _maxLifetime = 20.0f;

    Rigidbody _rb;
    Vector3 _direction = -Vector3.down;
    ObjectPool<TunnelPiece> _pool;
    float _selfDestructTime;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _rb.velocity = _direction * _speed;
        if (Time.time >= _selfDestructTime)
            SelfDestruct();
    }
    public void Build( Vector3 position, float speed)
    {
        transform.position = position;
        _speed= speed;
        _selfDestructTime = Time.time + _maxLifetime;
    }
    void SelfDestruct()
    {
        _pool.Release(this);
    }
    public void SetPool(ObjectPool<TunnelPiece> pool)
    {
        _pool = pool;
    }
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
