using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 200;
    public float directionalSpeed = 10;

    public bool canMoveHorizontal = true;
    public bool canMoveVertical = false;
    private float nextX = 0.0f;
    private float nextZ = 0.0f;
    private Vector3 currentPosition = Vector3.zero;
    private Vector3 nextPosition = Vector3.zero;

    private Rigidbody rigidBody = null;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        currentPosition = transform.position;
        Debug.Log(moveHorizontal + ", " + moveVertical);

        if (canMoveHorizontal)
        {
            nextX = Mathf.Clamp(currentPosition.x + moveHorizontal, -2.5f, 2.5f);
        }
        else
        {
            nextX = currentPosition.x;
        }

        if (canMoveVertical)
        {
            nextZ = Mathf.Clamp(currentPosition.z + moveVertical, -2.5f, 2.5f);
        }
        else
        {
            nextZ = currentPosition.z;
        }

        nextPosition = new Vector3(nextX, gameObject.transform.position.y, nextZ);
        transform.position = Vector3.Lerp(currentPosition, nextPosition, directionalSpeed * Time.deltaTime);
#endif
        rigidBody.velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        // mobile controls

        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0.0f, 0.0f, 10.0f));
        if (Input.touchCount > 0)
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);
        }
    }
}
