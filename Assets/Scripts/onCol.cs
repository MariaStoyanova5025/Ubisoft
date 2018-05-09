using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCol : MonoBehaviour {
    public string tag;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == tag)
        {
            Destroy(collision.gameObject);
        }
    }
}
