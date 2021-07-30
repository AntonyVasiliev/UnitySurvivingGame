using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float _dayLenght = 2880f;
    [SerializeField] [Range(0, 1)] private float _currentTime;

    private void FixedUpdate()
    {
        _currentTime += Time.deltaTime / _dayLenght;

        if (_currentTime >= 1 || _currentTime < 0) _currentTime = 0;
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }
}
