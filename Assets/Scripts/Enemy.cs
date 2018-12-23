using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    

    public float moveSpeed = 5f;
    public float lifeTime = 2f;
    public GameObject deadEffect;

    public float turnSpeed = .1f;
    public float repelRange = .5f;
    public float repelAmount = 1f;

    private Rigidbody2D rb;


	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Die());
    }

    void FixedUpdate()
    {

        Vector2 direction = PlayerController.positionPlayer;

        Vector2 newPos;

        newPos = Vector2.MoveTowards(transform.position, direction,Time.deltaTime * moveSpeed);//

        rb.MovePosition(newPos);
        Debug.Log("FixedUpdateEnemy " + direction.x + " " + direction.y);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(lifeTime);

        GameObject effect = Instantiate(deadEffect, transform.position, transform.rotation);
        effect.transform.localScale = transform.localScale;
        Destroy(effect, 5f);
        Destroy(gameObject);

    }
}
