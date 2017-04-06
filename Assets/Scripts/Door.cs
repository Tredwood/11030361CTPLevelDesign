using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
    [SerializeField]
    LevelManager lvlMan;
    public bool open = false;
    public bool locked = false;
    public Rigidbody rb;
    Vector3 fullOpen = new Vector3(0, -5, 0);
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fullOpen += transform.position;
    }

    void FixedUpdate () {
        
        if (open && !locked)
        {
            if (transform.position != fullOpen)
            {
                rb.MovePosition(transform.position - transform.up * Time.deltaTime);
            }
            else
            {
                open = false;
            }

        }
        
	}

    void OnCollisionEnter(Collision coll)
    {
        if (locked && (lvlMan.keysHeld != 0))
        {
            if (coll.gameObject.tag == "player")
            {
                lvlMan.keysHeld--;
                locked = false;
            }
        }
    }
}
