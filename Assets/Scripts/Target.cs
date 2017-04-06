using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {
    Challenge challenge;
    Transform Player;

    void Start()
    {
        Player = GameObject.FindWithTag("player").transform;
        challenge = GetComponentInParent<Challenge>();
    }

    void Update()
    {
        transform.LookAt(Player);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "arrow" || col.gameObject.tag == "arrow2")
        {
            challenge.enemies--;
            Destroy(gameObject);
        }
    }
}
