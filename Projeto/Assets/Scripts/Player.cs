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
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }   
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("Run", false);
        }
    }
     void OnCollisionEnter2D (Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Chão")
        {
            Pulan = false;
            anim.SetBool("DJump", false);
            anim.SetBool("Jump", false);

        }
        if(colisao.gameObject.tag == "Espinho")
        {   
            GameController.instace.ShowGameOver();
            Destroy(gameObject);
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
                anim.SetBool("Jump", true);

            }
            else
            {
                if(doublejum)
                {
                    rb.AddForce(new Vector2(0f, force), ForceMode2D.Impulse);
                    anim.SetBool("Jump", false);
                    anim.SetBool("DJump", true);
                    doublejum = false;
                }
            }
        }
    }
    
}
