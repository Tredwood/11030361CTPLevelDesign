using UnityEngine;
using System.Collections;

public class TargetChallenge : MonoBehaviour {
    public GameObject target;

    float x, y, z;
    Vector3 pos, initialPos;

    void Start()
    {

        int i = 0;
        int targNum = Random.Range(3, 7);
        initialPos = transform.parent.parent.position;
        while (i < targNum)
        {
            x = (initialPos.x + Random.Range(-3, 3));
            y = (initialPos.y + Random.Range(2, 3));
            z = (initialPos.x + Random.Range(-3, 3));
            pos = new Vector3(x, y, z);
            Quaternion rot = Quaternion.FromToRotation(Vector3.right, initialPos);
            GameObject Target = Instantiate(target, pos, rot) as GameObject;
            Target.transform.parent = transform;
            i++;
        }

    }

}
