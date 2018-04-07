using UnityEngine;

public class Hunter : Character
{
    
    [SerializeField] private float moveSpeed;
    public GameObject poisonArrow;
    
    protected override void Start()
    {
        base.Start();
        MoveSpeed = moveSpeed;
        HealthPoints = 4;
        BatteryCharge = 4;
    }

    protected override void OnMainSkillUse()
    {
        Shoot(poisonArrow);
    }

    protected override void OnSecondarySkillUse()
    {
        GameObject boss = GameObject.Find("Boss");
        Vector3 bossPosition = boss.transform.position;
        Vector3 bossForward = boss.transform.up;
        transform.position = new Vector3(bossPosition.x - (bossForward.x * 30), bossPosition.y - (bossForward.y * 30));
    }

    protected override void OnThirdSkillUse()
    {
        base.OnThirdSkillUse();
    }
}
