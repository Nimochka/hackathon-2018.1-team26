using System;
using SocketIO;
using UnityEngine;


public partial class SocketController
{

    public static event Action OnSocketOpen;
    public static event Action<TickData> OnPlayerTick;


    private void OnConnected(SocketIOEvent socketEvent)
    {
        if (socket.sid != null)
        {
            SocketId = socket.sid;
            if (OnSocketOpen != null)
                OnSocketOpen();
        }
    }


    private void OnTickReceived(SocketIOEvent socketEvent)
    {
        if (OnPlayerTick != null)
            OnPlayerTick(JsonUtility.FromJson<TickData>(socketEvent.data.ToString()));
    }

}
