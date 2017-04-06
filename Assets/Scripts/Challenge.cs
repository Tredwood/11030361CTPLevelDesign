using UnityEngine;
using System.Collections;

public class Challenge : MonoBehaviour {
    public GameObject enemy;
    public GameObject target;

    public bool start = false;
    public int enemies, challenge;

    void Start()
    {
        enemies = Random.Range(1, 6);
        challenge = Random.Range(1,3);
    }


    void Update ()
    {
        if (start == true && enemies <= 0)
        {
            ChallengeComplete();
        }
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "player")
        {
            int num = 0;
            
            Vector3 pos = transform.position;
            ArrayList spawnPoints = new ArrayList();
            spawnPoints.Add(new Vector3(2.5f, 2.5f, 2.5f));
            spawnPoints.Add(new Vector3(0, 2.5f, 2.5f));
            spawnPoints.Add(new Vector3(-2.5f, 2.5f, 2.5f));
            spawnPoints.Add(new Vector3(2.5f, 2.5f, 0));
            spawnPoints.Add(new Vector3(-2.5f, 2.5f, 0));
            spawnPoints.Add(new Vector3(1.5f, 2.5f, 0));
            spawnPoints.Add(new Vector3(1.5f, 2.5f, 1.5f));

            while (num < enemies)
            {
                if (challenge == 1)
                {
                    GameObject monster = Instantiate(enemy, pos + (Vector3)spawnPoints[num], transform.rotation) as GameObject;
                    monster.transform.parent = transform;
                    num++;
                }
                else if (challenge == 2)
                {
                    int pointLength = spawnPoints.Count;
                    Debug.Log(pointLength);
                    int newPos = Random.Range(0, (pointLength));
                    Quaternion rot = Quaternion.FromToRotation(Vector3.forward, (Vector3)spawnPoints[newPos]);
                    GameObject Target = Instantiate(target, pos + (Vector3)spawnPoints[newPos], transform.rotation) as GameObject;
                    Target.transform.parent = transform;
                    spawnPoints.RemoveAt(newPos);
                    num++;
                }
            }
            start = true;
        }
    }

    void ChallengeComplete()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Door>().open = true;
        }
    }
}
