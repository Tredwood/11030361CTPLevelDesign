using UnityEngine;
using System.Collections;

public class Corridor : MonoBehaviour {
    [SerializeField]
    LevelManager lvlMan;

    Vector3 point1 = new Vector3(0, 0, 10f);
    Vector3 point2 = new Vector3(10f, 0, 10f);
    Vector3 point3 = new Vector3(-10f, 0, 10f);
    Vector3 point4 = new Vector3(10f, 0, 0);
    Vector3 point5 = new Vector3(-10f, 0, 0);
    Vector3 pos;

    public GameObject Room, mainRoom, sideRoom, hole;
    public int dir;
    public bool main = false;

    
    // Use this for initialization
    void Start ()
    {
        PointCheck(dir);
        if (main)
        {
            if (lvlMan.storyPoints == 3)
            {
                Room = Instantiate(hole, transform.position + pos, transform.rotation) as GameObject;
                lvlMan.storyPoints++;
            }
            else
            {
                Room = Instantiate(mainRoom, transform.position + pos, transform.rotation) as GameObject;
            }
        }
        else
        {
            Room = Instantiate(sideRoom, transform.position + pos, transform.rotation) as GameObject;
        }
    }

    void PointCheck(int rooms)
    {
        switch (rooms)
        {
            case 1:
                pos = point1;
                break;
            case 2:
                pos = point2;
                break;
            case 3:
                pos = point3;
                break;
            case 4:
                pos = point4;
                break;
            case 5:
                pos = point5;
                break;
        }
    }
}
