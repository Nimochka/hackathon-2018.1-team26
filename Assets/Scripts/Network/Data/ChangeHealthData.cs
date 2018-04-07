using UnityEngine;

[System.Serializable]
public class ChangeHealthData
{

    public ChangeHealthData(string socketId, int healthDelta)
    {
        SocketId = socketId;
        HealthDelta = healthDelta;
    }


    [SerializeField] public string SocketId;
    [SerializeField] public int HealthDelta;

}
