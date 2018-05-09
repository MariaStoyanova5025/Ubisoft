using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    public int speed = 10;
    void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    
}
