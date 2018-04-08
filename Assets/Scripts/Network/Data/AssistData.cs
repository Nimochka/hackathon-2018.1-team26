using System;
using UnityEngine;


[Serializable]
public class AssistData
{
    public AssistData(string socketId)
    {
        SocketId = socketId;
    }


    [SerializeField] public string SocketId;
}
