using UnityEngine;

public class TreesTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chapalax")
        {
            GetComponent<Rigidbody>().freezeRotation = false;
        }
    }
}
