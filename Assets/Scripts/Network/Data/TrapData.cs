using System;
using UnityEngine;


[Serializable]
public class TrapData
{
    public TrapData(string socketId)
    {
        SocketId = socketId;
    }


    [SerializeField] public string SocketId;

}
