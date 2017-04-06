using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    [SerializeField]
    LevelManager lvlMan;
    public Rigidbody rb;
    public GameObject arrow, arrow2;
    GameObject weapon;

    public float PlayerSpeedWalk = 5.5f;

    public float gravity = 10.0f;
    public float jumpHeight = 2.0f;

    public float maxVelocityChange = 15.0f;

    public bool IsJump = true;
    private bool grounded = false;

    public Vector3 targetVelocity = Vector3.zero;

    public float arrowSpeed = 20;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
        if (grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= PlayerSpeedWalk;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rb.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            rb.AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump Ability
            if (Input.GetButton("Jump") && IsJump)
            {
                rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
                grounded = false;
            }
        }
        if(lvlMan.hasUpgrade)
        {
            arrow = arrow2;
        }
        if (lvlMan.hasWeapon)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Quaternion rot = Quaternion.FromToRotation(Vector3.forward, transform.position);
                GameObject Arrow = Instantiate(arrow, transform.position, rot) as GameObject;
                Arrow.GetComponent<Rigidbody>().velocity = GetComponentInChildren<Camera>().transform.forward*arrowSpeed;
            }
        }

        // We apply gravity manually for more tuning control
        rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));

        
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.tag == "key")
        {
            Destroy(coll.gameObject);
            lvlMan.keysHeld++;
        }
        if (coll.gameObject.tag == "weapon")
        {
            lvlMan.hasWeapon = true;
        }
        if (coll.gameObject.tag == "weapon2")
        {
            lvlMan.hasUpgrade = true;
        }
        if (coll.gameObject.tag == "arrowpickup")
        {
            Destroy(coll.gameObject);
            arrowSpeed += 5f;
        }
        if (coll.gameObject.tag == "speedpickup")
        {
            Destroy(coll.gameObject);
            PlayerSpeedWalk += 0.5f;
        }
        if (coll.gameObject.tag == "portal")
        {
            transform.position = new Vector3(0,0.2f,0);
        }
    }

    void OnCollisionStay(Collision coll)
    {
        grounded = true;
    }

    //Calculates the jump height
    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }
}
