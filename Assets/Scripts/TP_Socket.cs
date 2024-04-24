using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Socket : MonoBehaviour
{
    public void AddToSocket(Obstacle obstacle)
    {
        obstacle.transform.parent = transform;
        obstacle.transform.position = transform.position;
        obstacle.transform.rotation = transform.rotation;
    }
    public void ClearSocket()
    {
        transform.DetachChildren();
    }
}
