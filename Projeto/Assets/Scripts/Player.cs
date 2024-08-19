using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float force;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        
    }
    void Move()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"),0f, 0f);
        transform.position += movimento * Time.deltaTime * speed;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
        }
    }

}
