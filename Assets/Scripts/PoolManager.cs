using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    [SerializeField] TunnelPiece _tunnelPiecePf;

    ObjectPool<TunnelPiece> _tunnelPiecePool;
    public static PoolManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        _tunnelPiecePool = new ObjectPool<TunnelPiece>(AddNewTunnelPieceToPool,
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
}
