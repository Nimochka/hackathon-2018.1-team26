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

    [SerializeField] LayerMask shootMask;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] GameObject muzzle;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bullet;
    
    float nextFire = 0f;

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
        
        if(Input.GetMouseButtonDown(0)){
             Shoot(bullet);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            OnMainSkillUse();
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            OnSecondarySkillUse();
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            OnThirdSkillUse();
        }
        
    }
    
    protected virtual void Shoot (GameObject bulletObject)
    {
        	
        GameObject mf = Instantiate(muzzleFlash, muzzle.transform.position, transform.rotation) as GameObject;
        mf.transform.parent = transform;

        fireBullet(bulletObject);
        
        GameObject.Destroy(mf, 0.1f);
        
    }

    protected virtual void fireBullet(GameObject bulletObject)
    {
        
        if (Time.time > nextFire) {
            nextFire = Time.time + fireRate;

            GameObject sBullet = Instantiate(bulletObject, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
            
            GameObject.Destroy(sBullet, 1f);

            SocketController.RequestPlayerShot(new ShotData(SocketController.SocketId, muzzle.transform.position,
                muzzle.transform.rotation.eulerAngles));
        }
        
    }

    protected virtual void FixedUpdate()
    {
        Move(); 
    }

    protected virtual void OnMainSkillUse()
    {
        
    }

    protected virtual void OnSecondarySkillUse(){}

    protected virtual void OnThirdSkillUse()
    {
    }
}
