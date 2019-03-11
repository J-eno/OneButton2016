using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	float targetRatio = 16f / 9f;

	public float shakeTime;
	public float shakeAmount;
	// Use this for initialization
	void Start () {
		Camera myCam = GetComponent<Camera> ();
		myCam.aspect = targetRatio;
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (shakeTime >= 0)
		{
			Vector2 shakePosition = Random.insideUnitCircle * shakeAmount;

			transform.position = new Vector3 (transform.position.x + shakePosition.x, transform.position.y + shakePosition.y, transform.position.z);

			shakeTime -= Time.deltaTime;
		}
		if (shakeTime <= 0) 
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(0,0,transform.position.z), 0.1f);
		}

	}
	public void ShakeCamera(float shakePower, float shakeDuration)
	{
		shakeAmount = shakePower;
		shakeTime = shakeDuration;
	}
}
