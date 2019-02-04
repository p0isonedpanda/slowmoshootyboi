using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public UnityEvent Moving, Standing;
    GameController gc;

    public float speed = 5.0f;
    [SerializeField]
    GameObject projectile, blood;

    // To fire the stuffs
    public float fireRate = 0.1f;
    float fireTimer = 0.0f;
    bool ready;

    [SerializeField]
    Color playerColor;
    [SerializeField]
    GameObject playerDeath;

    Rigidbody2D rb;
    SpriteRenderer sprite;

    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
	sprite = GetComponent<SpriteRenderer>();

	if (Moving == null)
	    Moving = new UnityEvent();

	if (Standing == null)
	    Standing = new UnityEvent();
    
    gc = GameObject.Find("GameController").GetComponent<GameController>();
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
	AnimateReady(fireTimer >= fireRate);

	if (Input.GetButton("Fire1") && fireTimer >= fireRate)
	{
	    fireTimer = 0.0f;
	    Instantiate(projectile, transform.position, transform.rotation);
	}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy") Die();
    }

    void AnimateReady (bool ready)
    {
        Color col;
        if (ready) col = Color.Lerp(sprite.color, playerColor, 0.1f);
        else col = Color.Lerp(sprite.color, Color.white, 0.1f);

        sprite.color = col;
    }

    void Die()
    {
        gc.EndGame();
        Instantiate(playerDeath, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
