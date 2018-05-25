using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour {
   	public Animator anim;
   	public float moveSpeed;
   	public float jumpSpeed = 100f;
   	public bool Saltando;
   	public bool Aire;
	private bool Dir;
   	public GameObject pelota;
   	public Transform TiroSpawn; 
	private SpriteRenderer prender;
	Rigidbody2D rb;


   void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Saltando = false;
		prender = gameObject.GetComponent<SpriteRenderer> ();



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
			Dir = true;
			Caminar ();
        }

		if (Input.GetKey(KeyCode.D))
        {
			Dir = false;
            rb.velocity = new Vector2(moveSpeed*Time.deltaTime, rb.velocity.y);
			Caminar ();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
			anim.SetBool ("isWalking", false);
            rb.velocity = new Vector2(0, rb.velocity.y);

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
			anim.SetBool ("isWalking", false);
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

	void Caminar()
	{
		Debug.Log (Dir);
		anim.SetBool("isWalking", true);
		if (Dir == true)
		{
			prender.flipX = true;
		}
		if (Dir == false)
		{
			prender.flipX = false;
		}
	}
}


