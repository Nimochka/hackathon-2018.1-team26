using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hunter : Character
{

    [SerializeField] private float moveSpeed;
    public GameObject poisonArrow;

    private PlayerBattery plBattery;

    private bool poisonInProgress;
    private bool teleportToBossInProgress;
    
    private SynchronizationController syncController;
    private List<OnlineCharacter> onlinePlayersList;
    
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
        
        onlinePlayersList = syncController.OnlineCharacters.Where(x => x.Value.Character == "Boss")
            .Select(x => x.Value)
            .ToList();
        
        GameObject boss = onlinePlayersList[0].gameObject;
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
