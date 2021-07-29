using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Light))]

public class DayNightController : MonoBehaviour
{
	[SerializeField] private GameObject gameController;
    [SerializeField] private Material skybox;
	private Transform transform;
	private Light light;
	[SerializeField] [Range(0, 1)] private float blend;

	private void Start()
    {
		transform = GetComponent<Transform>();

		light = GetComponent<Light>();

		light.enabled = false;
    }

	private void FixedUpdate()
	{
		//Get current time
		float time = gameController.GetComponent<TimeController>().GetCurrentTime();

		RotateSun(time);

		BlendSkyBox(time);
	}

	//Set skybox blend depending on time of day
	private void BlendSkyBox(float value)
    {
		if (value > 0.15f && value < 0.25f)
		{
			blend = 1f - (value - 0.15f) * 10f;
		}

		else if (value > 0.65f && value < 0.75f)
		{
			blend = (value - 0.65f) * 10f;
		}

		else if (value < 0.15f || value > 0.75f) blend = 1f;

		else if (value > 0.25f || value < 0.65f) blend = 0f;

		skybox.SetFloat("_Blend", blend);
	}

	//Set sun rotation depending on time of day and disable light during night
	private void RotateSun(float value)
    {
		transform.localRotation = Quaternion.Euler((value * 360f) - 90, 50, 0);

		if (value > 0.75f) light.enabled = false;

		if (value > 0.15f && value < 0.75f) light.enabled = true; 
	}
}
