using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecSpawner : MonoBehaviour
{
    public GameObject player;
	public GameObject[] trianglePrefabs; // selection of obstacles that can be spawned
	private Vector3 spawnObstaclePosition;

    // Update is called once per frame
    void Update()
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
		if(distanceToHorizon < 120)
		{
			SpawnTriangles();
		}
    }
	
	void SpawnTriangles()
	{
		spawnObstaclePosition = new Vector3(0.0f, 0.0f, spawnObstaclePosition.z + 30.0f);
		Instantiate(trianglePrefabs[(0)], spawnObstaclePosition, Quaternion.identity);
	}
}
