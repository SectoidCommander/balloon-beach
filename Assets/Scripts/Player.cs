using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject sceneManager;
    public float playerSpeed = 4;
    public float rotationFactor = 3.5f;
    public float touchSpeed = 10;
    public bool teleportSideMovement = false;
    public bool isFrozen;
    public bool isInGodMode = false;
    public AudioClip scoreUp;
    public AudioClip damage;
    public AudioClip hitEnemy;

    public bool canMoveHorizontal = true;
    public bool canMoveVertical = false;
    private float nextX = 0.0f;
    private float nextZ = 0.0f;
    private Vector3 currentPosition = Vector3.zero;
    private Vector3 targetPosition = Vector3.zero;
    private Vector3 nextPosition = Vector3.zero;

    private bool isSmashing = false;
    private float smashTimer = 0.0f;
    public float smashTimeLimit = 0.5f;
    private float originalPlayerSpeed = 0.0f;

    private MeshRenderer meshRenderer;
    public Material[] smashMaterials;
    public Material[] originalMaterials;
    private Vector3 originalScale;
    public float smashScaling = 1.2f;
    public float smashSpeedFactor = 2.0f;

    private Rigidbody rigidBody = null;

    public CameraFollow cameraFollow;

    // Start is called before the first frame update
    void Start() 
    {
        rigidBody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterials = meshRenderer.materials;
        originalScale = transform.localScale;
        cameraFollow.speed = playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        

        if ( (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !isSmashing && !cameraFollow.IsCatchingUp())
        {
            isSmashing = true;
            cameraFollow.InitiateCatchup();
            smashTimer = 0.0f;
            originalPlayerSpeed = playerSpeed;
            playerSpeed *= smashSpeedFactor;

        }

        if (isSmashing)
        {
            if(smashTimer <= smashTimeLimit)
            {
                smashTimer += Time.deltaTime;
                meshRenderer.materials = smashMaterials;
                transform.localScale = originalScale * smashScaling;
                
                //cameraFollow.ProportionalSpeed(0.7f);
                //cameraFollow.speed = this.playerSpeed;
            }
            else
            {
                // wind down
                isSmashing = false;
                smashTimer = 0.0f;
                playerSpeed = originalPlayerSpeed;
                meshRenderer.materials = originalMaterials;
                transform.localScale = originalScale;
                //cameraFollow.ResetSpeed();
            }
        }

        if (!isFrozen)
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
            transform.position = Vector3.Lerp(currentPosition, nextPosition, touchSpeed * Time.deltaTime);
#endif


#if UNITY_ANDROID

            //rigidBody.velocity = Vector3.forward * playerSpeed * Time.deltaTime;
            // mobile controls

            transform.Rotate(Vector3.right * playerSpeed * rotationFactor);

            currentPosition = transform.position;
            targetPosition = currentPosition + Vector3.forward * playerSpeed;

            Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0.0f, 0.0f, 10.0f));
            if (Input.touchCount > 0)
            {
                targetPosition.x = touch.x;
            }

            // movements to the side have different speed than forward and upward
            // the player either instantly moves to the target or moves towards it gradually
            if (teleportSideMovement)
            {
                nextPosition.x = Mathf.Clamp(targetPosition.x, -2.5f, 2.5f);
            }
            else
            {
                nextPosition.x = Mathf.Clamp(Mathf.Lerp(currentPosition.x, targetPosition.x, touchSpeed * Time.deltaTime), -2.5f, 2.5f);
            }
            nextPosition.y = Mathf.Lerp(currentPosition.y, targetPosition.y, playerSpeed * Time.deltaTime);
            nextPosition.z = Mathf.Lerp(currentPosition.z, targetPosition.z, playerSpeed * Time.deltaTime);

            // move towards target position
            transform.position = nextPosition;
#endif

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "scoreup")
        {
            GetComponent<AudioSource>().PlayOneShot(scoreUp, 1.0f);
        }
        if (other.gameObject.tag == "triangle" && !isInGodMode)
        {
            GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sceneManager.GetComponent<App_Initialize>().GameOver();
        }
        if (other.gameObject.tag == "enemy" && !isInGodMode)
        {
            // if we collide into an enemy, the player dies unless
            // he's in smash attack mode
            if (isSmashing)
            {
                GetComponent<AudioSource>().PlayOneShot(hitEnemy, 1.0f);
                other.gameObject.GetComponent<Enemy>().Kill();

            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
                sceneManager.GetComponent<App_Initialize>().GameOver();
            }
        }
    }

    public void SetFrozen(bool isFrozen)
    {
        this.isFrozen = isFrozen;
    }
}
