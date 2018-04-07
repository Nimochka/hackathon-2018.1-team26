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
        if (BatteryCharge > 0)
        {
            BatteryCharge--;
            Shoot(poisonArrow);
        }
    }
}
