using UnityEngine;
using System.Collections;

public class AnimatedUVs : MonoBehaviour {
		
	public float scrollSpeed = 0.02f;
		
	void Update()
	{
		float offset = Time.time * scrollSpeed;
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset % 1);
	}
}