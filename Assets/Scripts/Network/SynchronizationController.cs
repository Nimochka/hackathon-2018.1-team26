﻿using System.Collections.Generic;
using System.Linq;
using SocketIO;
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
        SocketController.OnPlayerDied += ReceivePlayerDied;
        SocketController.OnPlayerPoisoned += ReceivePlayerPoison;
        SocketController.OnShieldRaised += ReceivePlayerShield;
        SocketController.OnTankAssist += ReceivePlayerAssist;
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
        {
            if (healthChangeData.HealthDelta > 0)
                PlayerCharacter.GetComponent<PlayerHealth>().addDamage(healthChangeData.HealthDelta);
            else
                PlayerCharacter.GetComponent<PlayerHealth>().Heal(-healthChangeData.HealthDelta);
        }
    }


    private void ReceivePlayerShot(ShotData shotData)
    {
        OnlineCharacters[shotData.SocketId].FireBullet(shotData);
    }


    private void ReceivePlayerDied(DieData dieData)
    {
        OnlineCharacters[dieData.SocketId].Die();
    }


    private void ReceivePlayerPoison(PoisonData poisonData)
    {
        if (SocketController.SocketId == poisonData.SocketId)
            PlayerCharacter.GetComponent<PlayerHealth>().Poison();
    }


    private void ReceivePlayerShield(ShieldData shieldData)
    {
        OnlineCharacters[shieldData.SocketId].RaiseShield();
    }


    private void ReceivePlayerAssist(AssistData assistData)
    {
        if (SocketController.SocketId == assistData.SocketId)
            PlayerCharacter.GetComponent<Boss>().Assist(OnlineCharacters.First(pair => pair.Value.Character == "Tank").Value.gameObject);
    }
}
