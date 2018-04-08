using System.Collections.Generic;
using UnityEngine;


public class Boss : Character
{
    [SerializeField] private float moveSpeed;
    public float stunTime = 0;
    public GameObject dash;
    public bool destroyMode = false;

    private float regenTimer;

    private bool isAssisted;
    private Transform assistTarget;
    private float assistTimer;


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

    private void LateUpdate()
    {
        if (isAssisted)
        {
            if (Vector2.Distance(transform.position, assistTarget.position) < 190)
            {
                //transform.rotation = Quaternion.Lerp(transform.rotation,
                //    Quaternion.LookRotation(assistTarget.position - transform.position), 20 * Time.deltaTime);
                transform.up = assistTarget.position - transform.position;
                assistTimer -= Time.deltaTime;
                if (assistTimer <= 0)
                    isAssisted = false;
            }
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


    public void Assist(GameObject target)
    {
        isAssisted = true;
        assistTarget = target.transform;
        assistTimer = 5;
    }
}
