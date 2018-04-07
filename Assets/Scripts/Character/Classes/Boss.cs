using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Boss : Character
{
    [SerializeField] private float moveSpeed;
    public float stunTime = 0;
    public GameObject dash;
    public bool destroyMode = false;
    
    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;
        HealthPoints = 4;
        BatteryCharge = 4;
        
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
    }

    protected override void OnMainSkillUse()
    {
        GameObject sDash = Instantiate(dash, transform.position, transform.rotation);
    }
    
    

    //protected override void FixedUpdate()
    //{
    //    if (stunTime <= 0)
    //    {
    //        base.FixedUpdate();
    //    }
    //    else
    //    {
    //        stunTime -= Time.deltaTime;
    //    }
    //}


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (destroyMode && other.gameObject.tag == "destroyItems")
        {
            GameObject.Destroy(other.gameObject);
        }
    }
}
