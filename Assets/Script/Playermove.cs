using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    Transform obj;
    Vector3 upper = new Vector3(-10.5f, 4, 0);
    Vector3 lower = new Vector3(-10.5f, -4, 0);
    float speed = 7f;
    void Start()
    {
        obj=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        movePadel();
        restriction();

    }

    private void restriction()// use to restric player peddle to get out of window boundry
    {
        if (transform.position.y > 4)
        {
            transform.position = upper;
        }
        else if (transform.position.y < -4)
        {
            transform.position = lower;
        }
    }

    private void movePadel()// for player peddle movement
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            obj.position += Vector3.up * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        { obj.position += Vector3.down * speed * Time.deltaTime; }
    } 
}
