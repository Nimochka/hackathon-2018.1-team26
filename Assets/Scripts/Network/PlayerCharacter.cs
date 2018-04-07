using UnityEngine;


public class PlayerCharacter : MonoBehaviour
{

    void FixedUpdate()
    {
        SendTick();
    }


    private void SendTick()
    {
        SocketController.RequestPlayerTick(new TickData(SocketController.SocketId, transform.position,
            transform.rotation.eulerAngles));
    }

}
