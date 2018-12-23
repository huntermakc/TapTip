using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceParalaxing : MonoBehaviour {

    public SpriteRenderer sr;
	

	void Update ()
    {
        sr.material.SetVector("PlayerPosition", PlayerController.positionPlayer);
	}
}
