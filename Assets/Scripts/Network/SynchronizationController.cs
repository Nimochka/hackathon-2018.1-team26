using System.Collections.Generic;
using UnityEngine;


public class SynchronizationController : MonoBehaviour
{
    public readonly Dictionary<string, OnlineCharacter> OnlineCharacters = new Dictionary<string, OnlineCharacter>();
    public static PlayerCharacter PlayerCharacter;

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
            OnlineCharacters.Add(SocketController.CurrentPick.Boss,
                Spawner.SpawnOnlineCharacter("Boss", SocketController.CurrentPick.Boss));
        if (SocketController.CurrentPick.Hunter != SocketController.SocketId)
            OnlineCharacters.Add(SocketController.CurrentPick.Hunter,
                Spawner.SpawnOnlineCharacter("Hunter", SocketController.CurrentPick.Hunter));
        if (SocketController.CurrentPick.Support != SocketController.SocketId)
            OnlineCharacters.Add(SocketController.CurrentPick.Support,
                Spawner.SpawnOnlineCharacter("Support", SocketController.CurrentPick.Support));
        if (SocketController.CurrentPick.Tank != SocketController.SocketId)
            OnlineCharacters.Add(SocketController.CurrentPick.Tank,
                Spawner.SpawnOnlineCharacter("Tank", SocketController.CurrentPick.Tank));
    }


    private void ReceivePlayerTick(TickData tickData)
    {
        OnlineCharacters[tickData.SocketId].ReceiveTick(tickData);
    }


    private void ReceivePlayerHealthChange(ChangeHealthData healthChangeData)
    {
        if (healthChangeData.SocketId == SocketController.SocketId)
            PlayerCharacter.GetComponent<PlayerHealth>().addDamage(healthChangeData.HealthDelta);
    }


    private void ReceivePlayerShot(ShotData shotData)
    {
        OnlineCharacters[shotData.SocketId].FireBullet(shotData);
    }

}
