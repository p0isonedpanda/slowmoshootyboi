using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // Various controllers the player needs access to
	TimeController tc;

	public float speed = 5.0f;
	public float fireRate = 0.1f;
	public UnityEvent Moving, Standing;
	[SerializeField]
	GameObject projectile, blood;
	float fireTimer = 0.0f;
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		tc = GameObject.Find("TimeController").GetComponent<TimeController>();

		if (Moving == null)
		    Moving = new UnityEvent();

		if (Standing == null)
		    Standing = new UnityEvent();
	}

	void Update ()
	{
		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		    Moving.Invoke();
		else
		    Standing.Invoke();

		rb.transform.Translate(new Vector2( (Input.GetAxis("Horizontal") * speed) * Time.deltaTime, (Input.GetAxis("Vertical") * speed) * Time.deltaTime ));
	}
}
