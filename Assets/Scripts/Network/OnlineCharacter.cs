using UnityEngine;

public class OnlineCharacter : MonoBehaviour
{
    public string Character;

    private TickData prevTickData, newTickData;
    private float lerpTimer;

    public GameObject Bullet, Muzzle;
    public GameObject MuzzleFlashPrefab;


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


    public void FireBullet(ShotData shotData)
    {
        GameObject bullet = Instantiate(Bullet, shotData.Position, Quaternion.Euler(shotData.Rotation));
        Destroy(bullet, 1f);

        GameObject muzzleFlash = Instantiate(MuzzleFlashPrefab, Muzzle.transform.position, transform.rotation, transform);
        Destroy(muzzleFlash, 0.1f);
    }

}
