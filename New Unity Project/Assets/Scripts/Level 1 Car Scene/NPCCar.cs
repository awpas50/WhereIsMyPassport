using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCar : MonoBehaviour
{
    public float speed;
    private float initialSpeed;

    public void Start()
    {
        initialSpeed = speed;
    }
    public virtual void Update()
    {
        //movement
        transform.position += Vector3.right * Time.deltaTime * speed;
        if(Input.GetKeyDown(KeyCode.A))
        {
            speed = initialSpeed * 1.2f;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            speed = initialSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Car")
        {
            Debug.Log(other.gameObject);
            NPCCar otherCar = other.gameObject.GetComponent<NPCCar>();
            speed = otherCar.speed;
        }
    }
}
