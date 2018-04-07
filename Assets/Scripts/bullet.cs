using UnityEngine;

public class bullet : MonoBehaviour
{

    [SerializeField] float rocketSpeed;

    private Rigidbody2D myRB;

    public Vector2 bulletDirection;

    private bool Hit;

    public bool IsOnlineBullet;
    public GameObject Shooter;

    void Awake()
    {
        //		myRB = GetComponent<Rigidbody2D>();
        //		
        //		myRB.AddForce(transform.up * rocketSpeed, ForceMode2D.Impulse);

    }

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        if (!Hit)
            transform.position += transform.up * 500f * Time.deltaTime;

    }

    public void RemoveForce()
    {

        //myRB.velocity = new Vector2(0,0);
        Hit = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        HitOnShootable(other);

    }

    void HitOnShootable(Collider2D other)
    {
        if (other.gameObject != Shooter)
        {
            OnlineCharacter onlineCharacter = other.gameObject.GetComponent<OnlineCharacter>();
            if (onlineCharacter != null)
            {
                if (!IsOnlineBullet)
                    SocketController.RequstPlayerHealthChanged(new ChangeHealthData(onlineCharacter.SocketId, 1));

                RemoveForce();
                Destroy(gameObject);
            }
        }
    }
}
