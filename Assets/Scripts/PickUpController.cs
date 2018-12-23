using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour {

    public int speed;
	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 10);
	}
	
	// Update is called once per frame
	void LateUpdate()
    {
        if (transform.localScale.x<2)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.0f) * Time.deltaTime * speed;

        }
		
	}
}
