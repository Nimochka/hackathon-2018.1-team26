using System.Collections;
using UnityEngine;

public class Hunter : Character
{

    [SerializeField] private float moveSpeed;
    public GameObject poisonArrow;

    private PlayerBattery plBattery;

    private bool poisonInProgress;
    private bool teleportToBossInProgress;
    
    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;
        BatteryCharge = 10;
        
        plBattery = GetComponent<PlayerBattery>();
        poisonInProgress = false;
        teleportToBossInProgress = false;

    }

    protected override void OnMainSkillUse()
    {
        
        if (plBattery.currentEnergy < 4 || poisonInProgress)
            return;
        
        Shoot(poisonArrow);
        plBattery.discharge(4);
    }

    protected override void OnSecondarySkillUse()
    {
        
        if (plBattery.currentEnergy < 3 || teleportToBossInProgress)
            return;
        
        GameObject boss = FindObjectOfType<Boss>().gameObject;
        Vector3 bossPosition = boss.transform.position;
        Vector3 bossForward = boss.transform.up;
        transform.position = new Vector3(bossPosition.x - (bossForward.x * 30), bossPosition.y - (bossForward.y * 30));
        
        plBattery.discharge(3);
    }

    IEnumerator startPoisonArrow()
    {
     
        poisonInProgress = true;
        yield return new WaitForSeconds(20);
        poisonInProgress = false;
        
    }
    
    IEnumerator startTeleportToBoss()
    {
     
        teleportToBossInProgress = true;
        yield return new WaitForSeconds(2);
        teleportToBossInProgress = false;
        
    }
    
    protected override void OnThirdSkillUse()
    {
        base.OnThirdSkillUse();
    }
}
