using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    public float fallingTime;

    private TargetJoint2D target;

    private BoxCollider2D boxColl;
    // Start is called before the first frame update
    void Start()
    {   
        target = GetComponent<TargetJoint2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D (Collision2D colisao)
    {
        if(colisao.gameObject.tag == "Player")
        {
            Invoke("Falling", fallingTime);
        }
        
        
        
    } 
    void Falling()
    {
        target.enabled = false;
        boxColl.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D Collidor)
    {
        if (Collidor.gameObject.tag == "GameOver")
        {
            Destroy(gameObject);
        }
    }
}
