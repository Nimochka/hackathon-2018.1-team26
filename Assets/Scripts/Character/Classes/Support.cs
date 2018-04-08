using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Support : Character
{
    [SerializeField] private float moveSpeed;
    public GameObject health;
    public GameObject trap;
    
    //private PlayerBattery plBattery;

    private bool trapInProgress;
    
    public AudioSource asourceShot; 			//The players AudioSource that sounds will be played through
    public AudioClip standartShot;
    
    protected override void Start()
    {
        base.Start();
        BatteryCharge = 10;
        MoveSpeed = moveSpeed;

        plBattery = GetComponent<PlayerBattery>();
        trapInProgress = false;


    }
    
    /**
     * Хил
     */
    protected override void OnMainSkillUse()
    {
        if (plBattery.currentEnergy < 3)
            return;
        
        Shoot(health);
        plBattery.discharge(3);
    }

    protected override void Shoot(GameObject bulletObject)
    {
        base.Shoot(bulletObject);
        
        asourceShot.volume = .3f;
        asourceShot.PlayOneShot(standartShot);
        
    }

    /**
     * Ловушка-стан
     */
    protected override void OnSecondarySkillUse()
    {
        
        if (plBattery.currentEnergy < 4 || trapInProgress)
            return;
        
        Vector3 pos = transform.position;
        pos.x += transform.up.x * 20;
        pos.y += transform.up.y * 20;
        GameObject sBullet = Instantiate(trap, pos, transform.rotation) as GameObject;
        sBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.up.x * 90, transform.up.y * 90);
        StartCoroutine(startTrap());
        plBattery.discharge(4);

    }

    IEnumerator startTrap()
    {
        
        trapInProgress = true;
        yield return new WaitForSeconds(8);
        trapInProgress = false;
        
    }
    
}
