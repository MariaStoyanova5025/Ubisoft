using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroids2 : MonoBehaviour {

    public Vector3 halfExtents = new Vector3(6, 0, 4);
    float x;
    float z;
    Vector3 pos;
    Vector3 displacement = new Vector3(-7, 0, -5);
    void Update () {
        transform.position = Vector3.MoveTowards(transform.position, displacement, 3 * Time.deltaTime);
        transform.Rotate(Vector3.right * 100 * Time.deltaTime, Space.Self);
        if (transform.position.x > 6 || transform.position.z > 4)
        {
            x = -6;
            z = Random.Range(-4, 4);
            pos = new Vector3(x, 0, z);
            transform.position = pos;
            x = 7;
            z = Random.Range(-5,5);
            displacement = new Vector3(x, 0, z);
        }
        else if (transform.position.x < -6 || transform.position.z < -4)
        {
            x = 6;
            z = Random.Range(-4, 4);
            pos = new Vector3(x, 0, z);
            transform.position = pos;
            x = -7;
            z = Random.Range(-5, 5);
            displacement = new Vector3(x, 0, z);
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "TUES_PlayerShip")
        {
            Destroy(collision.gameObject);
        }
    }
}
