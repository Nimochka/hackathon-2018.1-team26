using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int HealthPoints { get; set; }
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
    [SerializeField] private GameObject bullet;
    public bool OnlinePlayer;
    
    float nextFire = 0f;

    private Rigidbody2D rg;

    private Aim AimController;
    
    protected virtual void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        AimController = GameObject.Find("Map").GetComponent<Aim>();
       
    }


    private void Move()
    {
        
        Vector2 rigV = Vector2.zero;

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

        rigV.Normalize();
        rigV *= MoveSpeed;
        rg.velocity = rigV;
        
        //Player Rotation
        Vector3 objectPos = new Vector3(0,0,0);
        Vector3 dir = new Vector3(0,0,0);

        objectPos = Camera.main.WorldToScreenPoint(transform.position);

        if (!AimController.lockCursor)
        {
            dir = AimController.mPos - objectPos;
        }
        else
        {
            dir = AimController.worldLock - new Vector2(transform.position.x, transform.position.y);

            //Если расстояние больше 80 юнитов то обрываем лок курсора
            if (Vector2.Distance(transform.position, AimController.worldLock) > 80f)
                AimController.lockCursor = false;

        }
        
        
	
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg - 90));;

    }


    protected virtual void Update()
    {

        if (!OnlinePlayer)
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

        if (Input.GetMouseButtonDown(1))
        {

            AimController.lockCursor = true;
            AimController.worldLock = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(1))
        {
            AimController.lockCursor = false;
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
            nextFire = Time.time;

            GameObject sBullet = Instantiate(bulletObject, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
            
            GameObject.Destroy(sBullet, 1f);

            SocketController.RequestPlayerShot(new ShotData(SocketController.SocketId, muzzle.transform.position,
                muzzle.transform.rotation.eulerAngles));
        }
        
    }

    protected virtual void FixedUpdate()
    {
        if (!OnlinePlayer)
        {
            Move(); 
        }
    }

    protected virtual void OnMainSkillUse()
    {
        
    }

    protected virtual void OnSecondarySkillUse(){}

    protected virtual void OnThirdSkillUse()
    {
    }
}
