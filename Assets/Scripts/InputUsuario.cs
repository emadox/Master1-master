using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputUsuario : MonoBehaviour {

	public float movimiento;
	public float burst;




	void Start (){
			
	}

	void Update () {
		if(Input.GetKey(KeyCode.A)){
			gameObject.transform.Translate (-movimiento*Time.deltaTime, 0,0);
		}

		if(Input.GetKey (KeyCode.D)){
			gameObject.transform.Translate(movimiento * Time.deltaTime, 0,0);
		}
		if (Input.GetKey(KeyCode.W)){
			gameObject.transform.Translate(0, movimiento * Time.deltaTime,0);
		}
		if (Input.GetKey(KeyCode.S)){
			gameObject.transform.Translate(0, -movimiento * Time.deltaTime,0);
		}
			
	}
}
