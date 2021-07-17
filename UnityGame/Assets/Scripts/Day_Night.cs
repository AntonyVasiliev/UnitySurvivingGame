using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night : MonoBehaviour
{
    public Material skybox;
    [Range(0, 1)] public float blend;
	public Transform directionalLight;
	public float fullDay = 2880f; 
	[Range(0, 1)] public float currentTime;

	void Start()
    {
		currentTime = 0.30f;
    }

	void Update()
	{

		currentTime += Time.deltaTime / fullDay;

		if (currentTime >= 1 || currentTime < 0) currentTime = 0;


		//blend
		if (currentTime > 0.21f)
        {
			if(currentTime < 0.25f)
            {
				blend = 1f - (currentTime - 0.21f) * 25f;
				skybox.SetFloat("_Blend", blend);
			}
        }
		if (currentTime > 0.75f)
		{
			if (currentTime < 0.79f)
			{
				blend = (currentTime - 0.75f) * 25f;
				skybox.SetFloat("_Blend", blend);
			}
		}

		directionalLight.localRotation = Quaternion.Euler((currentTime * 360f) - 90, 50, 0);
	}
}
