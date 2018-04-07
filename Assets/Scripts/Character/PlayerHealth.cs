using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth;
	float currentHealth;
	
	//HUD
	public Slider healthBar;
	public Image damageScreen;
	
	bool damaged = false;
	
	Color damagedColor = new Color(255f, 255f, 255f, 0.5f);
	float smoothColor = 5f;
	
	// Use this for initialization
	void Start () {
		
		currentHealth = fullHealth;
		
		//HUD init
		healthBar.maxValue = fullHealth;
		healthBar.value = fullHealth;

		damaged = false;
		
	}
	
	public void addDamage(float damage) {

		if (damage <= 0)
			return;

		currentHealth -= damage;
		damaged = true;

		healthBar.value = currentHealth;
		
		if (currentHealth <= 0) {
			makeDead();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		if (damaged) {
			damageScreen.color = damagedColor;
			damaged = false;
		} else {
			damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
		}
		
	}
	
	public void makeDead() {

		//Instantiate(deathFX, transform.position, transform.rotation);
		Destroy(gameObject);

	}
}
