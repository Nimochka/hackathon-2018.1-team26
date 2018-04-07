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

    public float MoveSpeed { get; protected set; }


    private Rigidbody2D rg;


    protected virtual void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }


    private void Move()
    {
        
        Vector2 rigV = rg.velocity;

        //Player Movement
        if(Input.GetKey(KeyCode.W)){
            rigV.y = MoveSpeed;
        }
		
        if(Input.GetKey(KeyCode.A)){
            rigV.x = -MoveSpeed;
        }
		
        if(Input.GetKey(KeyCode.S)){
            rigV.y = -MoveSpeed;
        }
		
        if(Input.GetKey(KeyCode.D)){
            rigV.x = MoveSpeed;
        }

        rg.velocity = rigV;
        
        //Player Rotation
        Vector3 objectPos = new Vector3(0,0,0);
        Vector3 dir = new Vector3(0,0,0);

        objectPos = Camera.main.WorldToScreenPoint(transform.position);
        dir = Input.mousePosition - objectPos; 
	
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90));;
        
//        Vector2 velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * MoveSpeed;
//        rg.velocity = velocity;
    }


    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {
        Move(); 
    }
}
