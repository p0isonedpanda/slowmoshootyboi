using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
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

		if (Moving == null)
		    Moving = new UnityEvent();

		if (Standing == null)
		    Standing = new UnityEvent();
	}

	void Update ()
	{
		if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
		{
		    Moving.Invoke();
		    rb.transform.Translate(new Vector2( (Input.GetAxisRaw("Horizontal") * speed) * Time.deltaTime, (Input.GetAxisRaw("Vertical") * speed) * Time.deltaTime ));
		}
		else Standing.Invoke();

        fireTimer += Time.deltaTime;

		if (Input.GetButton("Fire1") && fireTimer >= fireRate)
		{
			fireTimer = 0.0f;
			Moving.Invoke();
			Instantiate(projectile, transform.position, transform.rotation);
		}
	}
}
