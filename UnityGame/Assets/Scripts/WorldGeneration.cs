using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject[] stones;

    private void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            int rand = Random.Range(0, trees.Length);
            int xrand = Random.Range(0, 400);
            int zrand = Random.Range(0, 400);
            Instantiate(trees[rand], new Vector3(xrand, 100, zrand), Quaternion.identity);
        }
        for (int i = 0; i < 50; i++)
        {
            int rand = Random.Range(0, stones.Length);
            int xrand = Random.Range(0, 400);
            int zrand = Random.Range(0, 400);
            Instantiate(stones[rand], new Vector3(xrand, 100, zrand), Quaternion.identity);
        }
    }
}
