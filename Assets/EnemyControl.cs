using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {
	public float speed;

	public float z;

	// Use this for initialization
	void Start () 
	{
		speed = 2f;	


	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 position = transform.position;

		if (transform.eulerAngles.z == 90) //facing left
		{
			position = new Vector2 (position.x - speed * Time.deltaTime, position.y);
		}
		else if (transform.eulerAngles.z == 270f) //facing right
		{
			position = new Vector2 (position.x + speed * Time.deltaTime, position.y);
		}
		 if (transform.eulerAngles.z == 180f) //facing down
		{
			position = new Vector2 (position.x , position.y - speed * Time.deltaTime);
		}
		else if (transform.eulerAngles.z == 0) //facing up
		{
			position = new Vector2 (position.x , position.y + speed * Time.deltaTime);

		}

		transform.position = position;
	}
}
