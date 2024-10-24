using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    public GameObject block;
    public int numberOfCubes = 10;
    public float delay = 3.0f;
    public Material[] materials;
    private List<Vector3> positions = new List<Vector3>();
    private int objectCounter = 0;

    void Start()
    {
        Bounds platformBounds = GetComponent<Collider>().bounds;

        GenerateRandomPositions(platformBounds);

        StartCoroutine(GenerateObjects());
    }

    void GenerateRandomPositions(Bounds platformBounds)
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition;
            do
            {
                float randomX = Random.Range(platformBounds.min.x, platformBounds.max.x);
                float randomZ = Random.Range(platformBounds.min.z, platformBounds.max.z);
                randomPosition = new Vector3(randomX, platformBounds.max.y + 0.5f, randomZ);
            }
            while (positions.Contains(randomPosition));

            positions.Add(randomPosition);
        }
    }

    IEnumerator GenerateObjects()
    {
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            if (materials.Length > 0)
            {
                Material randomMaterial = materials[Random.Range(0, materials.Length)];
                newBlock.GetComponent<Renderer>().material = randomMaterial;
            }

            objectCounter++;
            yield return new WaitForSeconds(delay);
        }
    }
}
