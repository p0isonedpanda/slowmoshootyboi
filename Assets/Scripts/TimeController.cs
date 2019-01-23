using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
	PlayerController pc;

	float timeScale = 0.05f;

    void Start ()
	{
		pc = GameObject.Find("Player").GetComponent<PlayerController>();
		
		pc.Moving.AddListener(SetTimescale);
		pc.Standing.AddListener(ResetTimescale);
	}

	void Update ()
	{
		// Magic stuff that make the time go slow
		Time.timeScale = Mathf.Lerp(Time.timeScale, timeScale, 0.2f);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

    // Called when moving
	void SetTimescale ()
	{
		timeScale = 1.0f;
	}

    // Called when standing
	void ResetTimescale ()
	{
		timeScale = 0.05f;
	}
}
