using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour {

    public Vector3 halfExtents = new Vector3(6, 0, 4);
    float x;
    float z;
    Vector3 pos;
    Vector3 spawnpos;
    Vector3 displacement = new Vector3(-7, 0, -5);
    public GameObject shoot;
    public float InstantiationTimer = 2f;


    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, displacement, 1.5f * Time.deltaTime);
        transform.Rotate(Vector3.up * 100 * Time.deltaTime, Space.Self);
        if (transform.position.x > 6  || transform.position.z > 4)
        {
            x = Random.Range(-6, 6);
            z = -4;
            pos = new Vector3(x, 0, z);
            transform.position = pos;
            x = Random.Range(-7 , 7);
            z = 5;
            displacement = new Vector3(x, 0, z);
        } else if (transform.position.x < -6 || transform.position.z < -4)
        {
            x = Random.Range(-6, 6);
            z = 4;
            pos = new Vector3(x, 0, z);
            transform.position = pos;
            x = Random.Range(-7, 7);
            z = -5;
            displacement = new Vector3(x, 0, z);
        }
        CreatePrefab();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    void CreatePrefab()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            Instantiate(shoot, this.gameObject.transform.position, transform.rotation);
            InstantiationTimer = 5f;
        }
    }
}
