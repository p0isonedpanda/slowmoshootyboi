using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    float spawnTimer = 0.0f;
    int round = 1; // Use this to indicate how difficult the next wave of enemies will be
    Transform playerPos;
    [SerializeField]
    float spawnDelay = 0.5f;
    [SerializeField]
    int spawnCount = 2;
    [SerializeField]
    GameObject enemy;

    void Start ()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= spawnDelay)
        {
            // Spawn logic
            spawnTimer = 0.0f;
            int toSpawn = spawnCount * round;

            for (int i = 0; i < toSpawn; i++)
                Instantiate(enemy, RandomRect(playerPos.position, 30.0f, 20.0f), Quaternion.Euler(Vector3.zero));

            round++;
            if (round % 10 == 0) spawnTimer /= 2;
        }
    }

    Vector3 RandomRect(Vector3 center, float width, float height)
    {
        // Select whether we wanna pick from the left(0), right(1), top(2), or bottom(3)
        int side = Random.Range(0, 4);

        // This is horrible. Try rewriting it in the future
        Vector3 pos = Vector3.zero;
        float max, min;
        if (side == 0) // Left
        {
            pos.x = (width / 2 * -1) + center.x;
            max = (height / 2) + center.y;
            min = (height / 2 * -1) + center.y;
            pos.y = Random.Range(min, max);
        }
        else if (side == 1) // Right
        {
            pos.x = width / 2 + center.x;
            max = (height / 2) + center.y;
            min = (height / 2 * -1) + center.y;
            pos.y = Random.Range(min, max);
        }
        else if (side == 2) // Top
        {
            pos.y = height / 2 + center.y;
            max = (width / 2) + center.x;
            min = (width / 2 * -1) + center.x;
            pos.x = Random.Range(min, max);
        }
        else // Bottom
        {
            pos.y = (height / 2 * -1) + center.y;
            max = (width / 2) + center.x;
            min = (width / 2 * -1) + center.x;
            pos.x = Random.Range(min, max);
        }

        return pos;
    }
}
