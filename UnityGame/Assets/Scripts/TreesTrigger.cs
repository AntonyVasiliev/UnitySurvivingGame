using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesTrigger : MonoBehaviour
{
    public bool t = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chapalax")
        {
            t = true;
            GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
