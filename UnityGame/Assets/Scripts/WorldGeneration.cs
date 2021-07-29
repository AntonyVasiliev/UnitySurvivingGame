using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    [SerializeField] private GameObject[] trees;
    [SerializeField] private GameObject[] stones;

    private void Start()
    {
        GenerateObjects(trees, 100, 0, 400, 0, 400);
        GenerateObjects(stones, 100, 0, 400, 0, 400);
    }

    //generates objects in chosen radius
    private void GenerateObjects(GameObject[] objects, int amount, int x1Pos,
        int x2Pos, int y1Pos, int y2Pos)
    {
        for (int i = 0; i < amount; i++)
        {
            int rand = Random.Range(0, objects.Length);
            int xrand = Random.Range(x1Pos, x2Pos);
            int zrand = Random.Range(y1Pos, y2Pos);
            Instantiate(objects[rand], new Vector3(xrand, 100, zrand), Quaternion.identity);
        }
    }
}
