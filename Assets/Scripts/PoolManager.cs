using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [SerializeField] TunnelPiece _tunnelPiecePf;
    [SerializeField] Obstacle _testObstaclePf;

    ObjectPool<TunnelPiece> _tunnelPiecePool;
    ObjectPool<Obstacle> _testObstaclePool;
    public static PoolManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        _tunnelPiecePool = new ObjectPool<TunnelPiece>(AddNewTunnelPieceToPool,
            t => t.gameObject.SetActive(true),
            t => t.gameObject.SetActive(false));

        _testObstaclePool = new ObjectPool<Obstacle>(AddNewTestObstacleToPool,
            t => t.gameObject.SetActive(true),
            t => t.gameObject.SetActive(false));
    }
    TunnelPiece AddNewTunnelPieceToPool()
    {
        var piece = Instantiate(_tunnelPiecePf);
        piece.SetPool(_tunnelPiecePool);
        return piece;
    }
    public TunnelPiece GetTunnelPiece()
    {
        return _tunnelPiecePool.Get();
    }
    Obstacle AddNewTestObstacleToPool()
    {
        var piece = Instantiate(_testObstaclePf);
        piece.SetPool(_testObstaclePool);
        return piece;
    }
    public Obstacle GetTestObstacle()
    {
        return _testObstaclePool.Get();
    }
}
