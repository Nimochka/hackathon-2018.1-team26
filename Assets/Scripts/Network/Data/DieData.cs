using System;
using UnityEngine;

[Serializable]
public class DieData
{
    public DieData(string socketId)
    {
        SocketId = socketId;
    }


    [SerializeField] public string SocketId;

}
