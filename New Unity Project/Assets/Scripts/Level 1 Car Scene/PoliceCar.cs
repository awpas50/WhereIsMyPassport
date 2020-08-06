using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : NPCCar
{
    public bool tracePlayer = false;
    public bool tracePlayerTriggered = false;
    public float traceSpeed;
    bool reachDestination = false;
    public override void Update()
    {
        if(tracePlayer)
        {
            // 1. trace player
            float step = traceSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.localPosition, playerRef.transform.position, step);
            // 2. push player
            if(Vector3.Distance(playerRef.transform.position, transform.localPosition) <= 0.5f)
            {
                reachDestination = true;
            }
            if(reachDestination)
            {
                StartCoroutine(PushPlayer());
                tracePlayer = false;
            }
        }
        else
        {
            //movement
            transform.position += Vector3.right * Time.deltaTime * speed;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, 3.5f);

            if (hit.collider != null && (hit.collider.gameObject.tag == "Car" || hit.collider.gameObject.tag == "Ambulance" || hit.collider.gameObject.tag == "PoliceCar"))
            {
                Debug.DrawRay(transform.position, Vector3.right * 3.5f, Color.green);
                otherCar = hit.collider.gameObject.GetComponent<NPCCar>();
                otherCar.speed = speed;
            }

            // player.GetComponent<PlayerCar>().screenPos.x (0 ~~ 1)
            speed = initialSpeed * (2 - player.GetComponent<PlayerCar>().screenPos.x);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Player" && !tracePlayerTriggered)
        {
            tracePlayer = true;
            tracePlayerTriggered = true;
        }
    }

    IEnumerator PushPlayer()
    {
        float duration = 2f; // 1 seconds you can change this 
                             //to whatever you want
        float normalizedTime = 0;
        while (normalizedTime <= 1f)
        {
            normalizedTime += Time.deltaTime / duration;
            transform.position = Vector3.MoveTowards(transform.localPosition, playerRef.transform.position + new Vector3 (0, 0.3f, 0), traceSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
