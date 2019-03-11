using UnityEngine;
using System.Collections;

public class SensorSize : MonoBehaviour {
	public BoxCollider2D boxCollider;
	public GameObject player;
	Vector2 upDown = new Vector2(0.3f,9);
	Vector2 leftRight = new Vector2(0.3f,16);
	Vector2 startOffset = new Vector2 (0, 0);
	Vector2 targetOffset = new Vector2 (0, 3);
	public float growSpeed;
	float t = 0;
	string direction;


	// Update is called once per frame
	void Update () 
	{
		Rotato rotato = player.GetComponent<Rotato> ();
		if (rotato.target == -90f) 
		{
			t += Time.deltaTime;
			boxCollider.size = Vector2.Lerp (upDown, leftRight, growSpeed * t);
			boxCollider.offset = Vector2.Lerp(startOffset,targetOffset, growSpeed * t);
		} 
		else if (rotato.target == -270f) 
		{
			t += Time.deltaTime;
			boxCollider.size = Vector2.Lerp (upDown, leftRight, growSpeed * t);
			boxCollider.offset = Vector2.Lerp(startOffset,targetOffset, growSpeed * t);
		} 
		else if(rotato.target == 0) 
		{
			boxCollider.size = upDown;
			boxCollider.offset = startOffset;

		}
		else if(rotato.target == -180) 
		{
			boxCollider.size = upDown;
			boxCollider.offset = startOffset;
		}
		resetT ();
	
	}

	void resetT()
	{
		Rotato rotato = player.GetComponent<Rotato> ();
		string previousDirection = direction;
		if (rotato.target == -90f) 
		{
			direction = "Right";
		} 
		else if (rotato.target == -270f) 
		{
			direction = "Left";

		} 
		else if(rotato.target == 0) 
		{
			direction = "Up";


		}
		else if(rotato.target == -180) 
		{
			direction = "Down";

		}
		if (previousDirection != direction) 
		{
			t = 0;
		}
	}

}
