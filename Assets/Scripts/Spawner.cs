using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject PlayerHunter, PlayerTank, PlayerSupport, PlayerBoss, OnlineCharacterPrefab;


    void Start()
    {
        SpawnPlayerCharacter();
    }


    public PlayerCharacter SpawnPlayerCharacter()
    {
        GameObject prefab = PlayerBoss;
        if (SocketController.Character == "Tank")
            prefab = PlayerTank;
        else if (SocketController.Character == "Support")
            prefab = PlayerSupport;
        else if (SocketController.Character == "Hunter")
            prefab = PlayerHunter;
        PlayerCharacter playerCharacter = Instantiate(prefab).GetComponent<PlayerCharacter>();
        Camera.main.GetComponent<CameraFollow>().FollowTarget = playerCharacter.transform;
        return playerCharacter;
    }


    public OnlineCharacter SpawnOnlineCharacter()
    {
        OnlineCharacter onlineCharacter = Instantiate(OnlineCharacterPrefab).GetComponent<OnlineCharacter>();
        return onlineCharacter;
    }

}
