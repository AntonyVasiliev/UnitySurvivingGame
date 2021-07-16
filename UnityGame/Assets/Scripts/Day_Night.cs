using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Night : MonoBehaviour
{
    public Material skybox;
    [Range(0, 1)] public float blend;
    void Update()
    {
        skybox.SetFloat("_Blend", blend);
    }
}
