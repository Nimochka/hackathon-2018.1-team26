using UnityEngine;

[System.Serializable]
public class ShotData
{
    public ShotData(string socketId, Vector2 position, Vector3 rotation)
    {
        SocketId = socketId;
        Position = position;
        Rotation = rotation;
    }

    [SerializeField] public string SocketId;
    [SerializeField] public Vector2 Position;
    [SerializeField] public Vector3 Rotation;

}
