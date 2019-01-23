using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	PlayerController pc;
	Transform player;
	Camera cam;
	float refVel;
	float t = 0.02f;

	void Start ()
	{
		player = GameObject.Find("Player").transform;
		cam = GetComponent<Camera>();
		pc = GameObject.Find("Player").GetComponent<PlayerController>();

		pc.Moving.AddListener(SetCameraInterpolation);
		pc.Standing.AddListener(ResetCameraInterpolation);
	}
	
	void Update ()
	{
		cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, 5.0f, ref refVel, 1.0f);
		transform.position = Vector3.Lerp
		(
			transform.position,
			new Vector3(player.position.x, player.position.y, player.position.z - 10),
			t
		);
	}

    // Called when moving
	void SetCameraInterpolation ()
	{
		t = 0.2f;
	}

    // Called when standing
	void ResetCameraInterpolation ()
	{
		t = 0.02f;
	}
}
