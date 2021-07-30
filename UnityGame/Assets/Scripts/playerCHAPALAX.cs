using UnityEngine;

public class playerCHAPALAX : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _trigger;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _trigger.SetActive(true);
            Invoke("TriggerOff", 1f);
        }
    }

    private void TriggerOff()
    {
        _trigger.SetActive(false);
    }
}
