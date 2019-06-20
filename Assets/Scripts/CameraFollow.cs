using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject player;
	public float speed = 100.0f;
	public float trailDistance = 10.0f;
	private Transform cameraTransform = null;
	private Transform playerTransform = null;

    private bool isFrozen = false;

	void Start() 
	{
		cameraTransform = this.transform;
		playerTransform = player.transform;
	}

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isFrozen)
        {
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, new Vector3(0, cameraTransform.position.y, playerTransform.position.z - trailDistance), Time.deltaTime * speed);
        }        
    }

    public void FreezeCamera(bool isFrozen)
    {
        this.isFrozen = isFrozen;
    }
}
