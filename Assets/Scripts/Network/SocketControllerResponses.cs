﻿using System;
using SocketIO;
using UnityEngine;
using UnityEngine.SceneManagement;


public partial class SocketController
{

    public static event Action OnSocketOpen;
    public static event Action<TickData> OnPlayerTick;
    public static event Action<ChangeHealthData> OnPlayerHealthChanged;
    public static event Action<ShotData> OnPlayerShot;
    public static event Action<Pick> OnGetPick;
    public static event Action OnGameStarted;
    public static event Action<DieData> OnPlayerDied;
    public static event Action<PoisonData> OnPlayerPoisoned;
    public static event Action<ShieldData> OnShieldRaised;
    public static event Action<AssistData> OnTankAssist; 


    public static event Action OnPlayerConnectSuccess, OnPlayerConnectFail;


    private void OnConnected(SocketIOEvent socketEvent)
    {
        if (socket.sid != null)
        {
            SocketId = socket.sid;
            if (OnSocketOpen != null)
                OnSocketOpen();
        }
    }


    private void ResponsePlayerTick(SocketIOEvent socketEvent)
    {
        if (OnPlayerTick != null)
            OnPlayerTick(JsonUtility.FromJson<TickData>(socketEvent.data.ToString()));
    }


    private void ResponsePlayerChangeHealth(SocketIOEvent socketEvent)
    {
        if (OnPlayerHealthChanged != null)
            OnPlayerHealthChanged(JsonUtility.FromJson<ChangeHealthData>(socketEvent.data.ToString()));
    }


    private void ResponsePlayerShot(SocketIOEvent socketEvent)
    {
        if (OnPlayerShot != null)
            OnPlayerShot(JsonUtility.FromJson<ShotData>(socketEvent.data.ToString()));
    }


    private void ResponsePlayerConnectSuccess(SocketIOEvent socketEvent)
    {
        if (OnPlayerConnectSuccess != null)
            OnPlayerConnectSuccess();
    }


    private void ResponsePlayerConnectFail(SocketIOEvent socketEvent)
    {
        if (OnPlayerConnectFail != null)
            OnPlayerConnectFail();
    }


    private void ResponseGetPick(SocketIOEvent socketEvent)
    {
        if (OnGetPick != null)
            OnGetPick(JsonUtility.FromJson<Pick>(socketEvent.data.ToString()));
    }


    private void ResponseGameStarted(SocketIOEvent socketEvent)
    {
        if (OnGameStarted != null)
            OnGameStarted();
    }


    private void ResponsePlayerDied(SocketIOEvent socketEvent)
    {
        if (OnPlayerDied != null)
            OnPlayerDied(JsonUtility.FromJson<DieData>(socketEvent.data.ToString()));
    }


    private void ResponsePlayerPoisoned(SocketIOEvent socketEvent)
    {
        if (OnPlayerPoisoned != null)
            OnPlayerPoisoned(JsonUtility.FromJson<PoisonData>(socketEvent.data.ToString()));
    }


    private void ResponsePlayerShield(SocketIOEvent socketEvent)
    {
        if (OnShieldRaised != null)
            OnShieldRaised(JsonUtility.FromJson<ShieldData>(socketEvent.data.ToString()));
    }


    private void ResponsePlayerAssist(SocketIOEvent socketEvent)
    {
        if (OnTankAssist != null)
            OnTankAssist(JsonUtility.FromJson<AssistData>(socketEvent.data.ToString()));
    }
}
