using System;
using UnityEngine;

[Serializable]
public class PickData
{
    public PickData(string socketId, string character)
    {
        SocketId = socketId;
        Character = character;
    }


    [SerializeField] public string SocketId;
    [SerializeField] public string Character;
}
