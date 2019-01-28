using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Moving, Standing;

    public float speed = 5.0f;
    [SerializeField]
    GameObject projectile, blood;

    // To fire the stuffs
    public float fireRate = 0.1f;
    float fireTimer = 0.0f;
    bool ready;

    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
	anim = GetComponent<Animator>();

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
	if (fireTimer >= fireRate) anim.SetBool("ready", true);

	if (Input.GetButton("Fire1") && fireTimer >= fireRate)
	{
	    fireTimer = 0.0f;
	    anim.SetBool("ready", false);
	    Instantiate(projectile, transform.position, transform.rotation);
	}
    }
}
