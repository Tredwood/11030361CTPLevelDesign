using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour {

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "arrow")
        {
            GetComponentInParent<Story>().complete = true;
            Destroy(gameObject);
        }
    }
}
