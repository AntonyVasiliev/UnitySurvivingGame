using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Light))]

public class DayNightController : MonoBehaviour
{
	[SerializeField] private GameObject _gameController;
    [SerializeField] private Material _skybox;
	private Transform _transform;
	private Light _light;
	[SerializeField] [Range(0, 1)] private float _blend;

	private void Start()
    {
		_transform = GetComponent<Transform>();

		_light = GetComponent<Light>();

		_light.enabled = false;
    }

	private void FixedUpdate()
	{
		//Get current time
		float time = _gameController.GetComponent<TimeController>().GetCurrentTime();

		RotateSun(time);

		BlendSkyBox(time);
	}

	//Set skybox blend depending on time of day
	private void BlendSkyBox(float value)
    {
		if (value > 0.15f && value < 0.25f)
		{
			_blend = 1f - (value - 0.15f) * 10f;
		}

		else if (value > 0.65f && value < 0.75f)
		{
			_blend = (value - 0.65f) * 10f;
		}

		else if (value < 0.15f || value > 0.75f) _blend = 1f;

		else if (value > 0.25f || value < 0.65f) _blend = 0f;

		_skybox.SetFloat("_Blend", _blend);
	}

	//Set sun rotation depending on time of day and disable light during night
	private void RotateSun(float value)
    {
		_transform.localRotation = Quaternion.Euler((value * 360f) - 90, 50, 0);

		if (value > 0.75f) _light.enabled = false;

		if (value > 0.15f && value < 0.75f) _light.enabled = true; 
	}
}
