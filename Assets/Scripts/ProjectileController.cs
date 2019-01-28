using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;

    Vector2 dir;
    Vector3 mousePos;
    Rigidbody2D rb;
    Camera cam;

    void Start ()
    {
	rb = GetComponent<Rigidbody2D>();
	cam = Camera.main;
	mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
	dir = -(transform.position - mousePos).normalized;
	transform.LookAt(mousePos, Vector3.left);
	Destroy(gameObject, 5.0f);
    }

    void Update ()
    {
	rb.MovePosition((Vector2)transform.position + (dir * speed * Time.deltaTime));
    }

    void OnTriggerEnter2D (Collider2D col)
    {
	if (col.tag == "Enemy")
	{
            
            Destroy(gameObject);
	    col.gameObject.GetComponent<EnemyController>().Destroy();
	}
    }
}
