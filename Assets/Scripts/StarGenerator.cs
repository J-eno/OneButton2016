using UnityEngine;
using System.Collections;

public class StarGenerator : MonoBehaviour 
{
	public GameObject starGO;
	public int maxStars;
	Color[] starColors = { 
		new Color (0.5f, 0.5f, 1f), 
		new Color(0f, 1f,1f), 
		new Color(1f,1f,0f), 
		new Color(255f,100f,100f),
		new Color(255f,255f,255f)
	};
	// Use this for initialization
	void Start () 
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		for (int i = 0; i < maxStars; ++i) 
		{
			GameObject star = (GameObject)Instantiate (starGO);
			star.GetComponent<SpriteRenderer> ().color = starColors [i % starColors.Length];
			star.transform.position = new Vector2 (Random.Range (min.x, max.x), Random.Range (min.y, max.y));
			star.GetComponent<Star> ().speed = (1f * Random.value + 5.5f);
			star.transform.parent = transform;
		}
	}
}
