using UnityEngine;

public class playerCHAPALAX : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject trigger;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            trigger.SetActive(true);
            Invoke("TriggerOff", 1f);
        }
    }

    private void TriggerOff()
    {
        trigger.SetActive(false);
    }
}
