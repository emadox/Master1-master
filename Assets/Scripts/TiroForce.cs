using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroForce : MonoBehaviour {
    public float tirostart;
    public float tresegundos = 3f;
    public float speed;
    public Transform TiroPos;
    private GameObject TiroSpawn;
    private Vector2 Mouse;
    private Rigidbody2D Tiro;
    
    // Use this for initialization
    void Start() {

        tirostart = Time.time + tresegundos;

        Mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 50f;
        TiroSpawn = GameObject.FindGameObjectWithTag("Tiro");
        TiroPos = TiroSpawn.GetComponent<Transform>();
        Tiro = gameObject.GetComponent<Rigidbody2D>();
        //Tiro.velocity = new Vector2(Mouse.x - TiroPos.position.x, Mouse.y - TiroPos.position.y);
    }

    // Update is called once per frame
    void Update() {
        
        if (tirostart <= Time.time)
        {
            Destroy(gameObject);
        }
        Tiro.velocity = transform.right*speed;

        //position = Vector2 (transform.position.x + speed * Time.deltaTime, 0);
        
        //transform.position = Vector2.MoveTowards(transform.position, Mouse,speed*Time.deltaTime);
        //Mouse = new Vector2(Mouse.x , Mouse.y );
        //Debug.Log(Mouse);
	}

    void OnTriggerEnter2D(Collider2D otro)
    {
        if(otro.tag == ("Piso"))
        {
            Destroy(gameObject);
            Debug.Log("Entrando al Trigger");
        }
    }
}
