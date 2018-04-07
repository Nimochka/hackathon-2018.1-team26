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
        HealthPoints = 4;
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
    
    /**
     * Масс телепорт к себе
     */
    protected override void OnThirdSkillUse()
    {
        GameObject tank = GameObject.Find("Tank");
        GameObject hunter = GameObject.Find("Hunter");
        if (tank != null)
        {
            Teleport(tank);
        }

        if (hunter != null)
        {
            Teleport(hunter);
        }
    }

    private void Teleport(GameObject teleportGameObj)
    {
        teleportGameObj.transform.position = new Vector3(transform.position.x, transform.position.y);
    }
}
