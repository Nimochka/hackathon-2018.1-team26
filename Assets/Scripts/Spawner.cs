using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject PlayerCharacterPrefab, OnlineCharacterPrefab;


    void Start()
    {
        //SocketController.OnSocketOpen += () => SpawnPlayerCharacter();

        GameObject playerCharacter = Instantiate(PlayerCharacterPrefab);
        Camera.main.GetComponent<CameraFollow>().FollowTarget = playerCharacter.transform;
    }


    public PlayerCharacter SpawnPlayerCharacter()
    {
        PlayerCharacter playerCharacter = Instantiate(PlayerCharacterPrefab).GetComponent<PlayerCharacter>();
        Camera.main.GetComponent<CameraFollow>().FollowTarget = playerCharacter.transform;
        return playerCharacter;
    }


    public OnlineCharacter SpawnOnlineCharacter()
    {
        OnlineCharacter onlineCharacter = Instantiate(OnlineCharacterPrefab).GetComponent<OnlineCharacter>();
        return onlineCharacter;
    }

}
