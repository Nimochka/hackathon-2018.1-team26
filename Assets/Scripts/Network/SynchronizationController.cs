using System.Collections.Generic;
using UnityEngine;


public class SynchronizationController : MonoBehaviour
{
    public readonly Dictionary<string, OnlineCharacter> onlineCharacters = new Dictionary<string, OnlineCharacter>();

    public Spawner Spawner;


    void Start()
    {
        SpawnCharacters();
        SocketController.OnPlayerTick += ReceivePlayerTick;
        SocketController.OnPlayerHealthChanged += ReceivePlayerHealthChange;
        SocketController.OnPlayerShot += ReceivePlayerShot;
    }


    private void SpawnCharacters()
    {
        if (SocketController.CurrentPick.Boss != SocketController.SocketId)
            onlineCharacters.Add(SocketController.CurrentPick.Boss, Spawner.SpawnOnlineCharacter("Boss"));
        if (SocketController.CurrentPick.Hunter != SocketController.SocketId)
            onlineCharacters.Add(SocketController.CurrentPick.Hunter, Spawner.SpawnOnlineCharacter("Hunter"));
        if (SocketController.CurrentPick.Support != SocketController.SocketId)
            onlineCharacters.Add(SocketController.CurrentPick.Support, Spawner.SpawnOnlineCharacter("Support"));
        if (SocketController.CurrentPick.Tank != SocketController.SocketId)
            onlineCharacters.Add(SocketController.CurrentPick.Tank, Spawner.SpawnOnlineCharacter("Tank"));
    }


    private void ReceivePlayerTick(TickData tickData)
    {
        onlineCharacters[tickData.SocketId].ReceiveTick(tickData);
    }


    private void ReceivePlayerHealthChange(ChangeHealthData healthChangeData)
    {

    }


    private void ReceivePlayerShot(ShotData shotData)
    {
        onlineCharacters[shotData.SocketId].FireBullet(shotData);
    }

}
