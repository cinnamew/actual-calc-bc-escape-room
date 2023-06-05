using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] Vector3 startPos;
    public float moveSpeed = 0.1f;
    public float moveScale = 0.1f;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);
    private Camera mainCam;
    private bool colliding;
    private Vector3 prevPos;

    void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        startPos = this.transform.position;
        print(startPos);
    }

    void Update()
    {
        if(position.y < -1) position.y = -1;
        prevPos = position;
        mousePosition = Input.mousePosition;
        //print("mouse pos: " + mousePosition);
        mousePosition = mainCam.ScreenToWorldPoint(mousePosition);
        mousePosition += new Vector3(0.5f, -0.5f, 0);
        Vector3 aa = startPos + moveScale*mousePosition;
        //Debug.Log("before: " + aa.x);
        //aa.x = Mathf.Clamp(aa.x, -500, 500);
        //print("after: " + aa.x);
        position = Vector2.Lerp(transform.position, aa, moveSpeed);
        colliding = false;
        //print(position);
    }

    void FixedUpdate() {
        rb.MovePosition(position);
        //print(position);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //print(collision.gameObject.tag);
        if(collision.gameObject.tag == "border") {
            colliding = true;
            if(prevPos != null) position = prevPos;
        //    Debug.Log("hit!");
            //Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
            
        }else {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>());
        }
    }

}