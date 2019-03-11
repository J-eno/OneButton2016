using UnityEngine;
using System.Collections;

public class Rotato : MonoBehaviour {
	public float target;
	public float turnSpeed = 10f;
	public float turnCd = 0.2f;
	// Use this for initialization
	void Start () 
	{ 
		
	}
		
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Z) && turnCd >= 0.2f)
		{
			target -= 90f;
			if (target <= -360f) 
			{
				target = 0f;
			}
			turnCd = 0;
		}
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (0, 0, target), turnSpeed* Time.deltaTime);
		turnCd += Time.deltaTime;
	}
}
