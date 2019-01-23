using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
	PlayerController pc;

    void Start ()
	{
		pc = GameObject.Find("Player").GetComponent<PlayerController>();
		
		pc.Moving.AddListener(SetTimescale);
		pc.Standing.AddListener(ResetTimescale);
	}

	void Update ()
	{
		// Magic stuff that make the time go slow
		Time.timeScale = Mathf.Lerp(Time.timeScale, 0.05f, 0.2f);
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

	void SetTimescale ()
	{
		Time.timeScale = 1.0f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}

	void ResetTimescale ()
	{
		Time.timeScale = 0.05f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
	}
}
