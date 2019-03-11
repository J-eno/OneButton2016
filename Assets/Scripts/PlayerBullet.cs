using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour 
{
	float speed;
	public GameObject player;
	Vector2 position;
	Vector2 velocity;

	// Use this for initialization


	void Start () 
	{
		speed = 10f;
		player = GameObject.Find ("Player");
		Rotato rotato = player.GetComponent<Rotato> ();
		position = transform.position;
		transform.rotation = Quaternion.Euler (0, 0, rotato.target);

		//Handles which direction the bullet should fly
		if(rotato.target == -90f)
		{
			velocity = new Vector2 (position.x + speed *Time.deltaTime, position.y);
		}
		else if(rotato.target == -180f)
		{
			velocity = new Vector2 (position.x, position.y - speed *Time.deltaTime);
		}
		else if(rotato.target == -270f )
		{
			velocity = new Vector2 (position.x - speed *Time.deltaTime, position.y);
		}
		else if(rotato.target == 0)
		{
			velocity = new Vector2 (position.x, position.y + speed * Time.deltaTime);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		position += velocity;
		transform.position = position;

		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		if (transform.position.x > max.x  || transform.position.x < min.x ) 
		{
			Destroy (gameObject);
		}
		if (transform.position.y > max.y  || transform.position.y < min.y ) 
		{
			Destroy (gameObject);
		}
	}

}
