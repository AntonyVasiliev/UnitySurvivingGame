using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float dayLenght = 2880f;
    [SerializeField] [Range(0, 1)] private float currentTime;

    private void FixedUpdate()
    {
        currentTime += Time.deltaTime / dayLenght;

        if (currentTime >= 1 || currentTime < 0) currentTime = 0;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}
