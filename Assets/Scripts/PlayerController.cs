using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 0.2f;
    public float rotationSpeed = 180f;
    public Vector3 halfExtents = new Vector3(6, 0, 4);

    public GameObject shoot;

    public GameObject asteroids;
    public float InstantiationTimer = 2f;
    Vector3 spawnpos;

    private void Start()
    {
        AsteroidsManager.Instance.RegisterPlayer(gameObject);
    }

   
    void CreatePrefab()
    {
        InstantiationTimer -= Time.deltaTime;
        if (InstantiationTimer <= 0)
        {
            spawnpos = new Vector3(Random.Range(-7, 7), 0, -5);
            Instantiate(asteroids, spawnpos, Quaternion.identity);
            InstantiationTimer = 5f;
        }
    }

    void Update()
    {
        CreatePrefab();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Quaternion offset = Quaternion.Euler(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);
        transform.rotation = transform.rotation * offset;
        Vector3 displacement = new Vector3(0f, 0f, verticalInput) * speed * Time.deltaTime;
        displacement = transform.rotation * displacement;
        Vector3 newPosition = transform.position + displacement;
        for (int i = 0; i < 3; ++i)
        {
            newPosition[i] = Mathf.Clamp(newPosition[i], -halfExtents[i], halfExtents[i]);
        }
        transform.position = newPosition;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnSpot = newPosition;
            Instantiate(shoot, spawnSpot, transform.rotation);

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("aasdfghjkl;lkjhgfdsasdfghjkl");
            Destroy(collision.gameObject);

        }
    }

    private void OnDestroy()
    {
        AsteroidsManager.Instance.UnregisterPlayer(gameObject);
    }
}
