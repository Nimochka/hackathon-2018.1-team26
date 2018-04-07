using UnityEngine;


public class Boss : Character
{
    [SerializeField] private float moveSpeed;
    public float stunTime = 0;
    public GameObject dash;
    public bool destroyMode = false;

    private float regenTimer;

    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;
        BatteryCharge = 10;

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
}
