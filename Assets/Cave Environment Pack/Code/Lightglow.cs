using UnityEngine;
using System.Collections;

public class Lightglow : MonoBehaviour {
	public  float baseSize;
	public  float sizeGrow;
	public  float speed;
	private float timer = 0.0f;
	private float size;
	private float scaleOffset;

	void Start()
	{
		scaleOffset = Random.Range(.9f, 1.1f);
	}

	void Update () {
		size = Mathf.PingPong(timer * (speed * scaleOffset), sizeGrow);
		timer += Time.deltaTime;
		gameObject.transform.localScale = new Vector3((size + baseSize), (size + baseSize), (size + baseSize));
	}
}