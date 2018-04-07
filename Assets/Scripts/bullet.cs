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
}
