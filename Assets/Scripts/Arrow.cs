using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    Rigidbody rb;
    bool grounded = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!grounded)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Room")
        {
            grounded = true;
        }
        if (coll.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
