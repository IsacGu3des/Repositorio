using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melon : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D Quadro;
    public GameObject Collected;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Quadro = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D (Collider2D Collidor)
    {
        if (Collidor.gameObject.tag == "Player")
        {
            sr.enabled = false;
            Quadro.enabled = false;
            Collected.SetActive(true);
            
            GameController.instace.TotalScore += score; 
            GameController.instace.UpdateScoreText();

            Destroy(gameObject, 0.25f);
        }
    }
}
