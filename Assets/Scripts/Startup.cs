using UnityEngine;
using System.Collections;

public class Startup : MonoBehaviour {
    [SerializeField]
    LevelManager lvlMan;
    public GameObject startPoint, storyPoint, player;

    Vector3 point = new Vector3(0,0,0);
    // Use this for initialization
    void Start () {

        lvlMan.storyPoints = 0;
        lvlMan.emptyPoints = 0;
        lvlMan.roomAmount = 0;
        lvlMan.keysHeld = 0;
        lvlMan.keys = 0;
        lvlMan.doors = 0;
        lvlMan.start = true;
        lvlMan.hasWeapon = false;
        lvlMan.hasUpgrade = false;
        Instantiate(startPoint, point, transform.rotation);
        Instantiate(player, new Vector3(0, 0.2f, 0), transform.rotation);
        //GameObject story = Instantiate(storyPoint, point + new Vector3(0, 0.1f, 0), transform.rotation) as GameObject;
    }
}
