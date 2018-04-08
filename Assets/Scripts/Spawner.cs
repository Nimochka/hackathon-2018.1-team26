﻿using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    public GameObject PlayerHunter, PlayerTank, PlayerSupport, PlayerBoss;
    public GameObject OnlineHunter, OnlineTank, OnlineSupport, OnlineBoss;

    public Slider HealthBar;
    public Image DamageScreen;

    public Slider EnergyBar;
    public Image EnergyScreen;

    void Start()
    {
        SpawnPlayerCharacter();
    }


    public PlayerCharacter SpawnPlayerCharacter()
    {
        //GameObject prefab = PlayerBoss;
        GameObject prefab = PlayerTank;
        if (SocketController.Character == "Tank")
            prefab = PlayerTank;
        else if (SocketController.Character == "Support")
            prefab = PlayerSupport;
        else if (SocketController.Character == "Hunter")
            prefab = PlayerHunter;
        PlayerCharacter playerCharacter = Instantiate(prefab).GetComponent<PlayerCharacter>();
        Camera.main.GetComponent<CameraFollow>().FollowTarget = playerCharacter.transform;
        
        PlayerHealth playerHealth = playerCharacter.GetComponent<PlayerHealth>();
        playerHealth.damageScreen = DamageScreen;
        playerHealth.healthBar = HealthBar;

        PlayerBattery playerBattery = playerCharacter.GetComponent<PlayerBattery>();
        playerBattery.chargeScreen = EnergyScreen;
        playerBattery.energyBar = EnergyBar;
        
        SynchronizationController.PlayerCharacter = playerCharacter;
        return playerCharacter;
    }


    public OnlineCharacter SpawnOnlineCharacter(string character, string socketId)
    {
        GameObject prefab = OnlineBoss;
        if (character == "Tank")
            prefab = OnlineTank;
        else if (character == "Support")
            prefab = OnlineSupport;
        else if (character == "Hunter")
            prefab = OnlineHunter;
        OnlineCharacter onlineCharacter = Instantiate(prefab).GetComponent<OnlineCharacter>();
        onlineCharacter.SocketId = socketId;
        return onlineCharacter;
    }

}
