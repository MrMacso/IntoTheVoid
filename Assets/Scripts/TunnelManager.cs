using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] GameObject testObject;
    List<TunnelPiece> _tunnelPieceList = new List<TunnelPiece>();
    List<Obstacle> _obstacleList = new List<Obstacle>();
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
            _obstacleList[0].SelfDestruct();
            RemoveObstacle(_obstacleList[0]);
            _tunnelPieceList[0].RemoveObstacles();
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
            BuildObstacle(piece);//testing

        }
        else
        {
            var pos = GetLastPiecePosition() - piece.GetHeightInVector();
            piece.Build(pos, _speed);
            AddTunnelPiece(piece);
            BuildObstacle(piece);//testing
        }
    }
    public void BuildObstacle(TunnelPiece piece)
    {
        Obstacle obstacle = PoolManager.Instance.GetTestObstacle();

        _obstacleList.Add(obstacle);

        int randomNum = Random.Range(0, 316);
        int normalized = randomNum - randomNum % 45;

        piece.AttachToSocket(obstacle, normalized);
    }
    void AddTunnelPiece(TunnelPiece tunnelPiece)
    {
        _tunnelPieceList.Add(tunnelPiece);
    }
    void RemoveTunnelPiece(TunnelPiece tunnelPiece)
    {
        _tunnelPieceList.Remove(tunnelPiece);
    }
    void AddObstacle(Obstacle obstacle)
    {
        _obstacleList.Add(obstacle);
    }
    void RemoveObstacle(Obstacle obstacle)
    {
        _obstacleList.Remove(obstacle);
    }
    Vector3 GetLastPiecePosition()
    {
        int count = _tunnelPieceList.Count - 1;
        return _tunnelPieceList[count].gameObject.transform.position;
    }
}
