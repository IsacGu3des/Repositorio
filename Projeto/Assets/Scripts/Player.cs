using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float force;
    private Rigidbody2D rb;
    public bool Pulan;
    public bool doublejum;
    
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
     void OnCollisionEnter2D (Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Chão")
        {
            Pulan = false;
        }
    }

    void OnCollisionExit2D (Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Chão")
        {   
            Pulan = true;
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(Pulan== false)
            {
                rb.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
                doublejum = true;
            }
            else
            {
                if(doublejum)
                {
                    rb.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
                    doublejum = false;
                }
            }
            
            
        }
    }
    
}
