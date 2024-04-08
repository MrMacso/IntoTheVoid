using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelController : MonoBehaviour
{
    [SerializeField] List<TunnelPiece> _tunnelPieceList = new List<TunnelPiece>();
    float _speed = 1.0f;
    void BuildTunnelPiece()
    {
        TunnelPiece piece = PoolManager.Instance.GetTunnelPiece();
        piece.Build(GetLastPiecePosition(), _speed);
    }
    void AddTunnelPiece(TunnelPiece tunnelPiece)
    {
        _tunnelPieceList.Add(tunnelPiece);
    }
    void RemoveTunnelPiece(TunnelPiece tunnelPiece)
    {
        _tunnelPieceList.Remove(tunnelPiece);
    }
    Vector3 GetLastPiecePosition()
    {
        int count = _tunnelPieceList.Count;
        return _tunnelPieceList[count].gameObject.transform.position;
    }
}
