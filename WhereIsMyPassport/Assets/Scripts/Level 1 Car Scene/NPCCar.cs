using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCar : MonoBehaviour
{
    public float speed;
    public float initialSpeed;

    [HideInInspector] public GameObject player;
    public GameObject playerRef;
    public NPCCar otherCar;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRef = player.GetComponent<PlayerCar>().playerRef;
        initialSpeed = speed;

        Physics2D.queriesStartInColliders = false;
        Debug.DrawRay(transform.position, Vector3.right * 3.5f, Color.red);
    }
    public virtual void Update()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}
