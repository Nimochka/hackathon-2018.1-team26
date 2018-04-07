using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int HealthPoints { get; protected set; }
    public int HealthCapacity { get; protected set; }

    public int BatteryCharge { get; protected set; }
    public int BatteryCapacity { get; protected set; }

    public Skill MainSkill { get; protected set; }
    public Skill SecondarySkill { get; protected set; }
    public Skill ThirdSkill { get; protected set; }

    public int MoveSpeed { get; protected set; }


    private Rigidbody2D rg;


    protected virtual void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }


    private void Move()
    {
        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * MoveSpeed;
        rg.velocity = velocity;
    }


    protected virtual void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move(); 
    }
}
