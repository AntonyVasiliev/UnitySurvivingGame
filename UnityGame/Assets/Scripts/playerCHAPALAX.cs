using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCHAPALAX : MonoBehaviour
{
    public Animator animator;
    public GameObject trigger;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            trigger.SetActive(true);
            Invoke("TriggerOff", 1f);
        }
    }
    void TriggerOff()
    {
        trigger.SetActive(false);
    }
}
