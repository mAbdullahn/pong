using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveBall : MonoBehaviour
{
    int enemyScr = 0;
    int playerScr= 0;
   // int enemyScr = 0;
    [SerializeField] Text playerScore;
    [SerializeField] Text enemyScore;
    public Vector2 Direction;
    float speed = 4.2f;
    private Rigidbody2D rb;
    [SerializeField]GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      

        // Initial movement direction
        Direction = Vector2.one.normalized;
        rb.velocity=Direction*speed;
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="wall")
        {
            Direction.y = -Direction.y;
            rb.velocity = Direction * speed;
            speed = speed+0.01f;
        }
        else if(collision.collider.tag=="padel")
        {
            Direction.x= -Direction.x;
            rb.velocity = Direction * speed;
            speed = speed + 0.3f;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "scorewall")
        {
            Vector2 starting = new Vector2(0, transform.position.y);
            playerScr++;
            playerScore.text = playerScr.ToString();
            obj.transform.position = starting;
            obj.transform.rotation = obj.transform.rotation;
        }
        else if (collision.collider.tag == "scorewall2")
        {
            Vector2 starting = new Vector2(0, transform.position.y);
            enemyScr++;
            enemyScore.text = enemyScr.ToString();
            obj.transform.position = starting;
            obj.transform.rotation = obj.transform.rotation;
        }
    }
}
