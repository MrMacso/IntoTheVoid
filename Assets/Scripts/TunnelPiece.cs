using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TunnelPiece : MonoBehaviour
{
    ObjectPool<TunnelPiece> _pool;

    float _speed = 2.0f;
    bool _isActive = true;

    readonly Vector3 _direction = -Vector3.down;
    void Update()
    {
        if (_isActive)
            transform.Translate(_direction * _speed);
    }
    public void Build( Vector3 position, float speed)
    {
        transform.position = position;
        _speed = speed;
    }
    public void SelfDestruct()
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
    public Vector3 GetHeightInVector()
    {
        var mesh = gameObject.GetComponentInChildren<MeshCollider>();
        var height = mesh.bounds.size.y;
        return new Vector3(0,height,0);
    }
}
