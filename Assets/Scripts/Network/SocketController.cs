using System;
using SocketIO;
using UnityEngine;


public partial class SocketController : MonoBehaviour
{

    private static SocketIOComponent socket;

    public static string SocketId;


    void Start()
    {
        socket = GetComponent<SocketIOComponent>();
        
        socket.On("open", OnConnected);
        socket.On("response:player:tick", OnTickReceived);

        socket.Connect();
    }


    public static void RequestPlayerTick(TickData tickData)
    {
        socket.Emit("request:player:tick", new JSONObject(JsonUtility.ToJson(tickData)));
    }
}
