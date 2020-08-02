using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : NPCCar
{
    public GameObject player;
    public bool tracePlayer = false;
    public GameObject playerRef;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRef = player.GetComponent<PlayerCar>().playerRef;
    }

    public override void Update()
    {
        if(tracePlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .03f);
        }
        else
        {
            //movement
            transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            tracePlayer = true;
        }
    }
}
