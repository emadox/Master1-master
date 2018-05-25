using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour {
    public Transform ptransform;
    Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        //gameObject.transform.Translate(0, 1*Time.deltaTime, 0);

        Vector3 ViewPos = cam.WorldToViewportPoint(ptransform.position);

        if (ViewPos.x > 0 && ViewPos.x <= 1 && ViewPos.y > 0 && ViewPos.y <= 1)
        {
            Debug.Log("In");
        }
        else
        {
            Debug.Log("Out");
        }
	}
}
