using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public GameObject player;
	public float speed = 6f;
	public float trailDistance = 5.0f;
	private Transform cameraTransform = null;
	private Transform playerTransform = null;
    public float initialSpeed = 0.0f;

    private bool isFrozen = false;

    public float catchupDistance = 100.0f;
    public float currentDistance = 0.0f;
    public float demoDistance = 0.0f;

    public bool isCatchingUp = false;

	void Start() 
	{
		cameraTransform = this.transform;
		playerTransform = player.transform;
        initialSpeed = speed;
    }

    private void Update()
    {
        CatchupCheck();
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

    public void ProportionalSpeed(float ratio)
    {
        if(ratio >= 0.0f && ratio <= 1.0f)
        {
            speed *= ratio;
        }
    }

    public void ResetSpeed()
    {
        speed = initialSpeed;
    }

    private void CatchupCheck()
    {
        currentDistance = Mathf.Abs(cameraTransform.position.z - playerTransform.position.z);

        if (isCatchingUp)
        {
            if (currentDistance <= catchupDistance)
            {
                isCatchingUp = false;
            }
        }
    }

    public bool IsCatchingUp()
    {
        return isCatchingUp;
    }

    public void InitiateCatchup()
    {
        isCatchingUp = true;
        this.catchupDistance = (float)Math.Round(currentDistance, 2);
    }
}
