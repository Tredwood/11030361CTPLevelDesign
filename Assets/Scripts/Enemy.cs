using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    Challenge challenge;
    Transform Player;

    public float MoveSpeed = 1f;
    public float MinDis = 1f;
    
    void Start ()
    {
        Player = GameObject.FindWithTag("player").transform;
        challenge = GetComponentInParent<Challenge>();
    }

    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= MinDis)
        {
            
            transform.position += transform.forward / MoveSpeed * Time.deltaTime;
            
        }
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
