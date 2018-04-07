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
        socket.On("response:player:tick", ResponsePlayerTick);
        socket.On("response:player:changehealth", ResponsePlayerChangeHealth);
        socket.On("response:player:shot", ResponsePlayerShot);

        socket.Connect();
    }


    public static void RequestPlayerTick(TickData tickData)
    {
        socket.Emit("request:player:tick", new JSONObject(JsonUtility.ToJson(tickData)));
    }


    public static void RequstPlayerHealthChanged(ChangeHealthData healthChangeData)
    {
        socket.Emit("request:player:changehealth", new JSONObject(JsonUtility.ToJson(healthChangeData)));
    }


    public static void RequestPlayerShot(ShotData shotData)
    {
        socket.Emit("request:player:shot", new JSONObject(JsonUtility.ToJson(shotData)));
    }
}
