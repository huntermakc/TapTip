using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public TouchPadController touchPad;
    public GameObject deadEffect;

    public float speed;

    public static Vector2 positionPlayer;

	// Use this for initialization
	void Start ()
    {
       
    }
	

	void FixedUpdate ()
    {
        
        Vector2 direction = touchPad.GetPosition();
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y)*Time.fixedDeltaTime*speed;

        Debug.Log("FixedUpdate " + direction.x + " " + direction.y);
        GetPositionPlayer();

    }

    void  GetPositionPlayer()
    {

        Debug.Log("" + this.transform.position.ToString());

        positionPlayer = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.life = false;
        GameObject effect = Instantiate(deadEffect, transform.position, transform.rotation);
        effect.transform.localScale = transform.localScale;
        Debug.Log(effect.transform.position);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

}
