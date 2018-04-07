using System;
using SocketIO;
using UnityEngine;


public partial class SocketController : MonoBehaviour
{

    private static SocketIOComponent socket;

    public static string SocketId, Character;


    void Start()
    {
        socket = GetComponent<SocketIOComponent>();

        socket.On("open", OnConnected);
        socket.On("response:player:tick", ResponsePlayerTick);
        socket.On("response:player:changehealth", ResponsePlayerChangeHealth);
        socket.On("response:player:shot", ResponsePlayerShot);
        socket.On("response:character:pick", ResponseGetPick);
        socket.On("response:game:start", ResponseGameStarted);

        socket.On("connect:success", ResponsePlayerConnectSuccess);
        socket.On("connect:failure", ResponsePlayerConnectFail);

        socket.Connect();
    }


    public static void Connect(string url = null)
    {
        if (url != null)
            socket.url = string.Format("ws://{0}/socket.io/?EIO=4&transport=websocket", url);
        socket.Connect();
    }


    public static void Close()
    {
        socket.Close();
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


    public static void RequestGetPick()
    {
        socket.Emit("request:player:pick");
    }


    public static void RequestSelectCharacter(PickData pickData)
    {
        socket.Emit("request:character:select", new JSONObject(JsonUtility.ToJson(pickData)));
    }
}
