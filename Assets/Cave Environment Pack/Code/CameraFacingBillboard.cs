using UnityEngine;
using System.Collections;


public class CameraFacingBillboard : MonoBehaviour
{
	
	public Camera m_Camera;
	public bool UseY = false;
	
	
	void Update()
	{
		Vector3 dir = Camera.main.transform.forward;

		if (!UseY)
		{
			dir.y = 0.0f;
		}

		transform.rotation = Quaternion.LookRotation(dir);
	}
}