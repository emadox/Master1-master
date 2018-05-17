using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour {

   public float moveSpeed;
   public float jumpSpeed = 100f;
   public bool Saltando;
   public bool Aire;
   public GameObject pelota;
    public Transform TiroSpawn; 
   Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Saltando = false;


    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Disparo();
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-moveSpeed*Time.deltaTime, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(moveSpeed*Time.deltaTime, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && !Saltando && !Aire)
        {
            Saltando = false;
			rb.velocity = new Vector2(0, jumpSpeed);
           
        }
        
     

    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Piso")
        {
            Saltando = false;
            Aire = false;

        }
    }

    void OnCollisionExit2D(Collision2D collaire)
    {
        if (collaire.gameObject.tag == "Piso")
        {
            Aire = true;
        }
    }

    void Disparo()
    {
        Instantiate(pelota, TiroSpawn.position, TiroSpawn.rotation);
    }
}


