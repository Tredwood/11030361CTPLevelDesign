using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
    Transform Player;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindWithTag("player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "arrow")
        {
            GetComponentInParent<Story>().complete = true;
        }
        if (col.gameObject.tag == "arrow2")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            GetComponentInParent<Story>().complete = true;
        }
    }
}
