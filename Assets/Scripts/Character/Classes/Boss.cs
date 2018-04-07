using UnityEngine;


public class Boss : Character
{
    [SerializeField] private float moveSpeed;
    public float stunTime = 0;

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

}
