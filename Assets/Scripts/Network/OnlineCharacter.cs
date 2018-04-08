using System.Collections;
using Skills;
using UnityEngine;

public class OnlineCharacter : MonoBehaviour
{
    public string Character;
    public string SocketId;

    private TickData prevTickData, newTickData;
    private float lerpTimer;

    public GameObject Bullet, Rocket, Heal, Muzzle;
    public GameObject MuzzleFlashPrefab;

    public SpriteRenderer SpriteRenderer;

    Rigidbody2D rg;
    public GameObject Shield;


    private bool playedStepSound;
    public AudioClip stepSound;
    public AudioClip shotSound;

    public AudioSource asourceStep;
    public AudioSource asourceShoot;

    public void ReceiveTick(TickData tickData)
    {
        prevTickData = newTickData;
        newTickData = tickData;
        lerpTimer = 0;
    }

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        playedStepSound = false;
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

            if (rg.velocity != new Vector2(0, 0))
            {
                if (Character == "Boss")
                {
                    if (!playedStepSound)
                    {
                        StartCoroutine(playStepSound());
                        asourceStep.PlayOneShot(stepSound);
                    }
                }
            }
        }
    }


    IEnumerator playStepSound()
    {
        asourceStep.volume = 0.2f;
        playedStepSound = true;
        yield return new WaitForSeconds(0.494f);
        playedStepSound = false;
    }

    public void FireBullet(ShotData shotData)
    {

        if (shotData.ProjectileName == "Rocket")
        {
            GameObject prefab = Rocket;
            rocket rocket = Instantiate(prefab, shotData.Position, Quaternion.Euler(shotData.Rotation))
                .GetComponent<rocket>();
            rocket.IsOnlineBullet = true;
            rocket.Shooter = gameObject;
            Destroy(rocket.gameObject, 1f);
        }
        else
        {
            GameObject prefab = Bullet;
            if (shotData.ProjectileName == "Health" || shotData.ProjectileName == "PoisonArrow")
                prefab = Heal;
            bullet bullet = Instantiate(prefab, shotData.Position, Quaternion.Euler(shotData.Rotation)).GetComponent<bullet>();
            bullet.IsOnlineBullet = true;
            bullet.Shooter = gameObject;
            Destroy(bullet.gameObject, 1f);
        }

        GameObject muzzleFlash = Instantiate(MuzzleFlashPrefab, shotData.Position, transform.rotation, transform);
        Destroy(muzzleFlash, 0.1f);

        if (Character == "Boss")
        {
            asourceShoot.volume = 3;
        }
        else
        {
            asourceShoot.volume = .3f;
        }

        asourceShoot.PlayOneShot(shotSound);

    }


    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        SpriteRenderer.color = Color.red;
    }


    public void RaiseShield()
    {
        Vector3 pos = transform.position;
        pos.x += transform.up.x * 20;
        pos.y += transform.up.y * 20;
        Shield sShield = Instantiate(Shield, pos, transform.rotation).GetComponent<Shield>();
        sShield.Tank = gameObject;
    }

}
