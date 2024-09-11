using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]float speed = 2.7f;
    public MoveBall ballScript;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        ballScript = GameObject.FindGameObjectWithTag("Ball").GetComponent<MoveBall>();
        rb=GetComponent<Rigidbody2D>();
       
    }
    private void Update()
    {
        Vector2 ballDirection = ballScript.Direction;
        rb.velocity = new Vector2(0, ballDirection.y*speed) ;

    }
    private void OnCollisionEnter2D(Collision2D collision)// to make enemy become faster each ball colide
    {
        if (collision.collider.tag == "Ball")
        {
            speed = speed + 0.7f;
        }
    }
}