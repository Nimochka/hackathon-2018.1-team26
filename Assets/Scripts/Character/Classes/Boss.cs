using System.Collections;
using UnityEngine;


public class Boss : Character
{
    [SerializeField] private float moveSpeed;
    public float stunTime = 0;
    public GameObject dash;
    public bool destroyMode = false;

    public rocket bossRocket;
    public GameObject muzzleRocket;

    private float regenTimer;

    private float nextFireRocket;

    private bool RocketInAir;

    private bool playedStepSound;
    
    //Audio
    public AudioSource asourceStep; 			//The players AudioSource that sounds will be played through
    public AudioSource asourceShot; 			//The players AudioSource that sounds will be played through
    public AudioClip stepSound;
    public AudioClip standartShot;
    public AudioClip missle;
    
    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;
        BatteryCharge = 10;

        RocketInAir = false;
        playedStepSound = false;

    }

    protected override void Update()
    {
        //Shoot(bullet);
        if (stunTime <= 0)
        {
            base.Update();
        }
        else
        {
            stunTime -= Time.deltaTime;
        }
        if (BatteryCharge < 10)
        {
            regenTimer += Time.deltaTime;
            if (regenTimer > 3)
                ++BatteryCharge;
        }

        if (rg.velocity != new Vector2(0, 0))
        {
            if (!playedStepSound)
            {
                StartCoroutine(playStepSound());
                asourceStep.PlayOneShot(stepSound);
            }
        }
        
    }

    protected override void Shoot(GameObject bulletObject)
    {
        base.Shoot(bulletObject);

        asourceShot.volume = 3;
        asourceShot.PlayOneShot(standartShot);
        

    }

    IEnumerator playStepSound()
    {

        asourceStep.volume = 0.2f;
        playedStepSound = true;
        yield return new WaitForSeconds(0.494f);
        playedStepSound = false;
    }

    protected override void OnThirdSkillUse()
    {

        if (plBattery.currentEnergy < 3 || RocketInAir)
            return;
        
        fireRocket();
        StartCoroutine(startFireRocket());
        plBattery.discharge(3);
        asourceShot.PlayOneShot(missle);

    }

    void fireRocket()
    {
        
        if (Time.time > nextFireRocket)
        {
            nextFireRocket = Time.time;

            rocket sBossRocket = Instantiate(bossRocket, muzzleRocket.transform.position, muzzleRocket.transform.rotation).GetComponent<rocket>();
            sBossRocket.Shooter = gameObject;
            sBossRocket.Damage = ShotDamage;

            Destroy(sBossRocket.gameObject, 1f);

            SocketController.RequestPlayerShot(new ShotData(SocketController.SocketId, muzzleRocket.transform.position,
                muzzleRocket.transform.rotation.eulerAngles));
        }
        
    }

    protected override void OnMainSkillUse()
    {
        GameObject sDash = Instantiate(dash, transform.position, transform.rotation);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (destroyMode && other.gameObject.tag == "destroyItems")
        {
            GameObject.Destroy(other.gameObject);
        }
    }

    IEnumerator startFireRocket()
    {

        RocketInAir = true;
        yield return new WaitForSeconds(1);
        RocketInAir = false;

    }
}
