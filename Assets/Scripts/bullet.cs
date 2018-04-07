using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	
	[SerializeField] float rocketSpeed;
	
	private Rigidbody2D myRB;

	public Vector2 bulletDirection;
	
	void Awake()
	{
		myRB = GetComponent<Rigidbody2D>();
		
		myRB.AddForce(transform.up * rocketSpeed, ForceMode2D.Impulse);
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RemoveForce() {

		myRB.velocity = new Vector2(0,0);

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		
		HitOnShootable(other);
		
	}

	void HitOnShootable(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
		{
			RemoveForce();
			Destroy(gameObject);
		} else if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
		{

			PlayerHealth plHealt = other.gameObject.GetComponent<PlayerHealth>();
			plHealt.addDamage(1f);
			
			RemoveForce();
			Destroy(gameObject);
		}
		
		
	}
}
