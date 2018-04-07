using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Support : Character
{
    [SerializeField] private float moveSpeed;
    public GameObject health;
    public GameObject trap;
    
    protected override void Start()
    {
        base.Start();
        BatteryCharge = 10;
        MoveSpeed = moveSpeed;
    }
    
    /**
     * Хил
     */
    protected override void OnMainSkillUse()
    {
        Shoot(health);
    }

    /**
     * Ловушка-стан
     */
    protected override void OnSecondarySkillUse()
    {
        Vector3 pos = transform.position;
        pos.x += transform.up.x * 20;
        pos.y += transform.up.y * 20;
        GameObject sBullet = Instantiate(trap, pos, transform.rotation) as GameObject;
        sBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.up.x * 90, transform.up.y * 90);
    }
    
}
