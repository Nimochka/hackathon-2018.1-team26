using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattery : MonoBehaviour {

	SynchronizationController SyncController;
	
	public float fullEnergy;
	public float currentEnergy;
	
	//HUD
	public Slider energyBar;
	public Image chargeScreen;
	
	private bool charged = false;
	private bool startCharged = false;
	
	Color chargeColor = new Color(255f, 255f, 255f, 0.5f);
	float smoothColor = 5f;

	private List<string> playersTypes;
	private List<OnlineCharacter> onlinePlayersList;

	private bool PlayersTogether;
	
	// Use this for initialization
	void Start () {
		
		currentEnergy = fullEnergy;
		
		//HUD init
		energyBar.maxValue = fullEnergy;
		energyBar.value = fullEnergy;

		charged = false;

		SyncController = GameObject.Find("SynchronizationController").GetComponent<SynchronizationController>();

		PlayersTogether = false;


	}
	
	public void addCharge(float charge) {

		if (currentEnergy >= fullEnergy)
			return;
		
		currentEnergy += charge;
		charged = true;

		energyBar.value = currentEnergy;

	}

	public void discharge(float countEnergy)
	{
		if (currentEnergy == 0)
			return;

		currentEnergy -= countEnergy;
		energyBar.value = currentEnergy;

	}
	
	// Update is called once per frame
	void Update () {
		
		onlinePlayersList = SyncController.OnlineCharacters.Where(x => x.Value.Character != "Boss")
			.Select(x => x.Value)
			.ToList();

		if (onlinePlayersList.Count == 2)
		{

			PlayersTogether = true;
			
			foreach (OnlineCharacter onPlayer in onlinePlayersList)
			{

				float DistanceAura = Vector2.Distance(transform.position,
					new Vector2(onPlayer.transform.position.x, onPlayer.transform.position.y));
				
				if (DistanceAura > 44)
				{
					PlayersTogether = false;
					break;
				}

			}
		}

		if (PlayersTogether && !startCharged && (currentEnergy < fullEnergy))
		{
			StartCoroutine(ChargePlayer());
		}
		
		if (charged) {
			chargeScreen.color = chargeColor;
			charged = false;
		} else {
			chargeScreen.color = Color.Lerp(chargeScreen.color, Color.clear, smoothColor * Time.deltaTime);
		}
		
	}

	IEnumerator ChargePlayer()
	{

	
			startCharged = true;
			yield return new WaitForSeconds(2);
			addCharge(1);
			charged = true;

			startCharged = false;
	
		
	}
	
}
