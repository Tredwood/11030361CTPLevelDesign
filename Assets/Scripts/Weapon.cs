using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "player")
        {
            GetComponentInParent<Story>().complete = true;
            Destroy(gameObject);
        }
    }
}
