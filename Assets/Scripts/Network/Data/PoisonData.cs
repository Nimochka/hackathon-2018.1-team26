using System;
using UnityEngine;

[Serializable]
public class PoisonData
{
    public PoisonData(string socketId)
    {
        SocketId = socketId;
    }

    [SerializeField] public string SocketId;
}