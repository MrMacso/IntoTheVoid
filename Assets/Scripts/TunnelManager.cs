using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelManager : MonoBehaviour
{
    [SerializeField] GameObject testObject;
    List<TunnelPiece> _tunnelPieceList = new();
    List<Obstacle> _obstacleList = new ();
    float _speed = 0.1f;
    int _damage = 6;
    const int MAX_TUNNELPIECE_INDEX = 15;
    readonly Vector3 START_POS = new (0,70,0);
    readonly Vector3 END_POS = new (0,250,0);

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
            DestroyTunnelPiece();
        }
    }
    void BuildTunnelPiece()
    {
        TunnelPiece tunnelPiece = PoolManager.Instance.GetTunnelPiece();
        var position = NextTunnelPiecePosition(tunnelPiece);

        tunnelPiece.Build(position, _speed);
        AddTunnelPieceToList(tunnelPiece);
        BuildObstacle(tunnelPiece);//testing
    }
    void DestroyTunnelPiece()
    {
        _obstacleList[0].SelfDestruct();
        RemoveObstacleFromList(_obstacleList[0]);

        _tunnelPieceList[0].RemoveObstacles();
        _tunnelPieceList[0].SelfDestruct();
        RemoveTunnelPieceFromList(_tunnelPieceList[0]);
    }
    Vector3 NextTunnelPiecePosition(TunnelPiece tunnelPiece)
    {
        Vector3 position;
        if (_tunnelPieceList.Count == 0)
        {
            position = START_POS;
        }
        else
        {
            position = GetLastPiecePosition() - tunnelPiece.GetHeightInVector();
        }
        return position;
    }
    public void BuildObstacle(TunnelPiece piece)
    {
        Obstacle obstacle = PoolManager.Instance.GetTestObstacle();

        AddObstacleToList(obstacle);

        int randomNum = Random.Range(0, 316);
        int normalized = randomNum - randomNum % 45;

        piece.AttachToSocket(obstacle, normalized, _damage);
    }

    void AddTunnelPieceToList(TunnelPiece tunnelPiece)
    {
        _tunnelPieceList.Add(tunnelPiece);
    }
    void RemoveTunnelPieceFromList(TunnelPiece tunnelPiece)
    {
        _tunnelPieceList.Remove(tunnelPiece);
    }
    void AddObstacleToList(Obstacle obstacle)
    {
        _obstacleList.Add(obstacle);
    }
    void RemoveObstacleFromList(Obstacle obstacle)
    {
        _obstacleList.Remove(obstacle);
    }
    Vector3 GetLastPiecePosition()
    {
        int count = _tunnelPieceList.Count - 1;
        return _tunnelPieceList[count].gameObject.transform.position;
    }
}
