using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Obstacle Settings")]
    [SerializeField] private GameObject podium;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float offsetAmount = 1f;
    [SerializeField] private float gap = 5f; // The gap between the obstacles
    [SerializeField] float offsetZ = 55.0f; // The offset of the obstacles along the z-axis

    private Vector3 scale;

    private void Start()
    {
        scale = podium.transform.localScale; // Get the scale of the podium
        // SpawnObstacle();

        TestSpawnObstacle();
    }

    private void TestSpawnObstacle()
    {
        print($"Podium scale at z: {scale.z}");

        float podiumZScale = scale.z; // Get the z-scale of the podium
        int numObstacles = Mathf.FloorToInt(podiumZScale / gap) / 2; // Get the number of obstacles that can fit in the podium

        for (int i = 0; i < numObstacles; i++)
        {
            float offset = (i % 2 == 0) ? -offsetAmount : offsetAmount;

            Vector3 pos = new Vector3(offset, transform.position.y + 1.5f, 4 * (i + 1) + (transform.position.z) + gap * i + offsetZ);

            Quaternion rotation = (i % 2 == 0) ? Quaternion.identity : Quaternion.Euler(0, 0, 180);

            Instantiate(obstaclePrefab, pos, rotation, transform.parent);
        }
    }

    // private void SpawnObstacle()
    // {
    //     if (obstaclePrefab != null)
    //     {
    //         float count = Mathf.Floor((transform.localScale.z / obstaclePrefab.transform.localScale.z) / 2);

    //         print($"Count: {count}");

    //         for (int i = 0; i < count; i++)
    //         {
    //             float offset = (i % 2 == 0) ? -offsetAmount : offsetAmount;

    //             Vector3 pos = transform.position + transform.forward * offset + Vector3.up * (transform.localScale.y / 2f + obstaclePrefab.transform.localScale.y) + transform.forward * (i * gap);

    //             // Vector3 pos = new Vector3(offset, transform.position.y + 1, 4 * (i + 1) + (transform.position.z) + spacing * i);

    //             Quaternion rotation = (i % 2 == 0) ? Quaternion.identity : Quaternion.Euler(0, 0, 180);

    //             Instantiate(obstaclePrefab, pos, rotation);
    //         }

    //     }
    // }
}
