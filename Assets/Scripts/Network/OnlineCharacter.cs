using UnityEngine;

public class OnlineCharacter : MonoBehaviour
{
    private TickData prevTickData, newTickData;
    private float lerpTimer;


    public void ReceiveTick(TickData tickData)
    {
        prevTickData = newTickData;
        newTickData = tickData;
        lerpTimer = 0;
    }


    void Update()
    {
        if (newTickData != null)
        {
            if (prevTickData != null)
            {
                transform.position = Vector2.Lerp(prevTickData.Position, newTickData.Position,
                    lerpTimer / Time.fixedDeltaTime);
                transform.rotation = Quaternion.Euler(Vector3.Lerp(prevTickData.Rotation,
                    newTickData.Rotation, lerpTimer / Time.fixedDeltaTime));
                lerpTimer += Time.deltaTime;
            }
            else
            {
                transform.position = newTickData.Position;
                transform.rotation = Quaternion.LookRotation(newTickData.Rotation);
            }
        }
    }

}
