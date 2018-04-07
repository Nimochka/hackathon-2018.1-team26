using System.Collections.Generic;
using UnityEngine;


public class SynchronizationController : MonoBehaviour
{

    private readonly Dictionary<string, OnlineCharacter> onlineCharacters = new Dictionary<string, OnlineCharacter>();

    public Spawner Spawner;


    void Start()
    {
        SocketController.OnPlayerTick += ReceivePlayerTick;
    }


    private void ReceivePlayerTick(TickData tickData)
    {
        if (!onlineCharacters.ContainsKey(tickData.SocketId))
            onlineCharacters.Add(tickData.SocketId, Spawner.SpawnOnlineCharacter());
        onlineCharacters[tickData.SocketId].ReceiveTick(tickData);
    }

}
