using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Support : Character
{
    [SerializeField] private float moveSpeed;
    public GameObject health;
    
    protected override void Start()
    {
        HealthPoints = 4;
        base.Start();

    }
    
    protected override void OnMainSkillUse()
    {
        Shoot(health);
    }
}
