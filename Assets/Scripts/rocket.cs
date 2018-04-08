using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour {

	[SerializeField] float rocketSpeed;

	private Rigidbody2D myRB;

	public Vector2 bulletDirection;

	private bool Hit;

	public bool IsOnlineBullet;
	public GameObject Shooter;
	public int Damage;

	// Update is called once per frame
	void Update()
	{

		if (!Hit)
			transform.position += transform.up * 500f * Time.deltaTime;

	}

	public void RemoveForce()
	{

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
				if (!IsOnlineBullet && (SocketController.Character != "Boss" && onlineCharacter.Character == "Boss" ||
				                        SocketController.Character == "Boss" && onlineCharacter.Character != "Boss"))
					SocketController.RequstPlayerHealthChanged(new ChangeHealthData(onlineCharacter.SocketId, Damage));

				RemoveForce();
				Destroy(gameObject);
			}
		}
	}
}
