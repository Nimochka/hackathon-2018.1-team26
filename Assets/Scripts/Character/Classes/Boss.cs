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
    
    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;
        HealthPoints = 4;
        BatteryCharge = 4;
        
    }

    protected override void Update()
    {
        if (stunTime <= 0)
        {
            base.Update();
        }
        else
        {
            stunTime -= Time.deltaTime;
        }
    }

    protected override void FixedUpdate()
    {
        if (stunTime <= 0)
        {
            base.FixedUpdate();
        }
        else
        {
            stunTime -= Time.deltaTime;
        }
    }


    
}
