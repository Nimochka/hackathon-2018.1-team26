using System.Collections.Generic;
using UnityEngine;


public class SynchronizationController : MonoBehaviour
{

    private readonly Dictionary<string, OnlineCharacter> onlineCharacters = new Dictionary<string, OnlineCharacter>();

    public Spawner Spawner;


    void Start()
    {
        SocketController.OnPlayerTick += ReceivePlayerTick;
        SocketController.OnPlayerHealthChanged += ReceivePlayerHealthChange;
        SocketController.OnPlayerShot += ReceivePlayerShot;
    }


    private void ReceivePlayerTick(TickData tickData)
    {
        if (!onlineCharacters.ContainsKey(tickData.SocketId))
            onlineCharacters.Add(tickData.SocketId, Spawner.SpawnOnlineCharacter());
        onlineCharacters[tickData.SocketId].ReceiveTick(tickData);
    }


    private void ReceivePlayerHealthChange(ChangeHealthData healthChangeData)
    {

    }


    private void ReceivePlayerShot(ShotData shotData)
    {
        if (!onlineCharacters.ContainsKey(shotData.SocketId))
            onlineCharacters.Add(shotData.SocketId, Spawner.SpawnOnlineCharacter());
        onlineCharacters[shotData.SocketId].FireBullet(shotData);
    }

}
