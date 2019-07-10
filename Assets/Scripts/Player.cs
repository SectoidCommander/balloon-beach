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

    public bool isSmashing = false;
    private bool isRecharging = false;
    private float smashRecharge = 0.0f;
    [Range(0.0f, 10.0f)]private float smashRechargeTimelimit = 0.5f;
    private float smashTimer = 0.0f;
    public float smashTimeLimit = 0.7f; // the length of smash mode in seconds
    private float originalPlayerSpeed = 0.0f;
    private bool doubleTapping = false;
    private int doubleTapFrameCount = 0; // counts the number of consequtive frames in which a double-tap has been registered

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

    private Rect windowRect = new Rect(20, 20, 500, 100);
    private string debugMessage = "";

    /*
    void OnGUI()
    {
        windowRect = GUI.Window(0, windowRect, WindowFunction, "My Window");
    }

    void WindowFunction(int windowID)
    {
        GUI.skin.label.fontSize = 25;
        GUI.Label(new Rect(25, 25, 500, 100), debugMessage);
    }
    */
    void DebugMessage(string message)
    {
        debugMessage = message;
    }

    // Update is called once per frame
    void Update()
    {

        

        int touchCount = Input.touchCount;
        
        string touchMessage = "";
        int tapCount = 0;

        if(touchCount > 0)
        {
            for (int x = 0; x < touchCount; x++)
            {
                tapCount = Input.GetTouch(x).tapCount;
                touchMessage = touchMessage + "Touch (" + x + "): " + tapCount ;
                if (Input.GetTouch(x).tapCount >= 2)
                {
                    doubleTapping = true;
                    doubleTapFrameCount++;
                    touchMessage = touchMessage + " DOUBLE FRAMECOUNT: " + doubleTapFrameCount;
                }
                touchMessage = touchMessage + "\n";
            }   
        }
        else
        {
            touchMessage = "";
            doubleTapping = false;
            doubleTapFrameCount = 0;
        }
        DebugMessage(touchMessage);

        if ( (doubleTapping && doubleTapFrameCount == 1) && !isSmashing && !isRecharging)
        {
            doubleTapping = false;
            isSmashing = true;
            isRecharging = true;
            cameraFollow.InitiateCatchup();
            smashTimer = 0.0f;
            originalPlayerSpeed = playerSpeed;
            playerSpeed *= smashSpeedFactor;
        }

        if (isRecharging)
        {
            if(smashRecharge >= smashRechargeTimelimit)
            {
                smashRecharge = 0.0f;
                isRecharging = false;
            }
            else {
                smashRecharge += Time.deltaTime;
            }
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
            if (Input.touchCount > 0 && !isSmashing)
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
                Destroy(other.gameObject);

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
