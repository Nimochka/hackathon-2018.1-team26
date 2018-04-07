using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Tank : Character
{
    [SerializeField] private float moveSpeed;
    public GameObject shield;
    public GameObject assist;
    public bool mainSkillLock = false;

    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;
        BatteryCharge = 10;
    }

    protected override void Shoot(GameObject bulletObject)
    {
        if (!mainSkillLock)
        {
            base.Shoot(bulletObject);
        }
    }

    protected override void OnMainSkillUse()
    {
        if (!mainSkillLock)
        {
            Vector3 pos = transform.position;
            pos.x += transform.up.x * 20;
            pos.y += transform.up.y * 20;
            GameObject sShield = Instantiate(shield, pos, transform.rotation) as GameObject;
            mainSkillLock = true;
        }
    }

    protected override void OnSecondarySkillUse()
    {
        GameObject sAssist = Instantiate(assist, transform.position, transform.rotation);
    }
}
