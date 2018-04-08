using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Skills;
using UnityEngine;


public class Tank : Character
{
    [SerializeField] private float moveSpeed;
    public GameObject shield;
    public GameObject assist;
    public bool mainSkillLock = false;

    private PlayerBattery plBattery;

    private bool assistInProgress;

    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;

        plBattery = GetComponent<PlayerBattery>();

        assistInProgress = false;
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

            if (plBattery.currentEnergy < 4)
                return;

            Vector3 pos = transform.position;
            pos.x += transform.up.x * 20;
            pos.y += transform.up.y * 20;
            Shield sShield = Instantiate(shield, pos, transform.rotation).GetComponent<Shield>();
            sShield.Tank = gameObject;
            mainSkillLock = true;
            plBattery.discharge(4);

            SocketController.RequestPlayerShield(new ShieldData(SocketController.SocketId));
        }
    }

    protected override void OnSecondarySkillUse()
    {

        if (plBattery.currentEnergy < 4)
            return;

        if (!assistInProgress)
        {
            GameObject sAssist = Instantiate(assist, transform.position, transform.rotation);
            plBattery.discharge(4);
            StartCoroutine(startAssist());
        }
    }

    IEnumerator startAssist()
    {

        assistInProgress = true;
        yield return new WaitForSeconds(10);
        assistInProgress = false;

    }
}
