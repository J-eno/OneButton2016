using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public GameObject PlayerBulletGO;
	public GameObject bulletPos;
	public GameObject player;
	public GameObject cam;

	void OnTriggerEnter2D(Collider2D info)
	{
		if (info.gameObject.tag == "Enemy") 
		{
			Shootem ();

		}
	}
	// Use this for initialization
	void Start ()
	{

	
	}
	public void Shootem()
	{
		CameraController camControl = cam.GetComponent<CameraController> ();
		GameObject bullet = (GameObject)Instantiate (PlayerBulletGO);
		bullet.transform.position = bulletPos.transform.position;
		camControl.ShakeCamera (0.07f, 0.2f);
	}
}
