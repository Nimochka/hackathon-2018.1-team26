using System;
using UnityEngine;


[Serializable]
public class ShieldData
{
    public ShieldData(string socketId)
    {
        SocketId = socketId;
    }


    [SerializeField] public string SocketId;
}
