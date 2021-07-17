using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] stones;

    private void Start()
    {
        for (int i = 0; i < 60; i++)
        {
            int rand = Random.Range(0, trees.Length - 1);
            int xrand = Random.Range(0, 300);
            int zrand = Random.Range(0, 300);
            Instantiate(trees[rand], new Vector3(xrand, 0, zrand), Quaternion.identity);
        }
        for (int i = 0; i < 30; i++)
        {
            int rand = Random.Range(0, stones.Length - 1);
            int xrand = Random.Range(0, 300);
            int zrand = Random.Range(0, 300);
            Instantiate(stones[rand], new Vector3(xrand, 0, zrand), Quaternion.identity);
        }
    }
}
