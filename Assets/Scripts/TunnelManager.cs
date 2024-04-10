using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    List<TunnelPiece> _tunnelPieceList = new List<TunnelPiece>();

    float _speed = 0.1f;

    const int MAX_TUNNELPIECE_INDEX = 15;
    readonly Vector3 START_POS = new Vector3(0,70,0);
    readonly Vector3 END_POS = new Vector3(0,250,0);

    void Awake()
    {
        for (int i = 0; i < MAX_TUNNELPIECE_INDEX; i++)
        {
            BuildTunnelPiece();
        }
    }
    void Update()
    {
        if(_tunnelPieceList.Count != MAX_TUNNELPIECE_INDEX)
        {
            BuildTunnelPiece();
        }
        if (_tunnelPieceList[0].transform.position.y > END_POS.y)
        {
            _tunnelPieceList[0].SelfDestruct();
            RemoveTunnelPiece(_tunnelPieceList[0]);
        }
    }
    void BuildTunnelPiece()
    {
        TunnelPiece piece = PoolManager.Instance.GetTunnelPiece();
        if(_tunnelPieceList.Count == 0)
        {
            piece.Build(START_POS, _speed);
            AddTunnelPiece(piece);
        }
        else
        {
            var pos = GetLastPiecePosition() - piece.GetHeightInVector();
            piece.Build(pos, _speed);
            AddTunnelPiece(piece);
        }
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
        int count = _tunnelPieceList.Count - 1;
        return _tunnelPieceList[count].gameObject.transform.position;
    }
}
