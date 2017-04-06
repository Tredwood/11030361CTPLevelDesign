using UnityEngine;
using System.Collections;

public class Side : MonoBehaviour {
    [SerializeField]
    LevelManager lvlMan;
    
    public GameObject key, arrowPower, speedPower;

    int pickup;
	
	void Start ()
    {
        pickup = Random.Range(1,4);

        switch(pickup)
        {
            case 1:
                Instantiate(key, transform.position + new Vector3(0, 1f, 0), transform.rotation);
                lvlMan.keys++;
                break;
            case 2:
                Instantiate(arrowPower, transform.position + new Vector3(0, 1f, 0), transform.rotation);
                break;
            case 3:
                Instantiate(speedPower, transform.position + new Vector3(0, 1f, 0), transform.rotation);
                break;
        }
    }
}
