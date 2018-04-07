using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Aim : MonoBehaviour {

	public Vector2 mouse;
	public Texture2D cursor;
	public Texture2D cursorLock;
	public int wSize;
	public int hSize;
	public bool lockCursor;

	public Vector2 charVelocity;

	private float x;
	private float y;

	public Vector3 mPos;

	public Vector2 worldLock;

	private float cursorX;
	private float cursorY;
	
	
	// Use this for initialization
	void Start () {
		
		Cursor.visible = false;
		lockCursor = false;

	}

	private void Update()
	{
		
		mouse = new Vector2(x, Screen.height - y);

		if (!lockCursor)
		{
			x = Input.mousePosition.x;
			y = Input.mousePosition.y;
			
		}
		else
		{
			
//			x -= charVelocity.x;
//			y -= charVelocity.y;

			mouse = Camera.main.WorldToScreenPoint(worldLock);
			
			Vector2 mouseV = new Vector2(mouse.x, Screen.height - mouse.y);
			mouse = mouseV;

		}
		
		Cursor.visible = false;

		cursorX = mouse.x - (wSize / 2);
		cursorY = mouse.y - (hSize / 2);

		if (!lockCursor)
		{
			mPos = new Vector2(x,y);
		}
		else
		{
			mPos = new Vector2(cursorX,cursorY);
		}
		
		
	}

	private void OnGUI()
	{

		if (!lockCursor)
		{
			GUI.DrawTexture(new Rect(cursorX, cursorY, wSize, hSize), cursor);
		}
		else
		{
			GUI.DrawTexture(new Rect(cursorX, cursorY, wSize, hSize), cursorLock);
		}

		Cursor.visible = false;
		
	}

}
