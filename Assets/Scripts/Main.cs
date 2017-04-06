using UnityEngine;
using System.Collections;

public class Main: MonoBehaviour
{
    [SerializeField] LevelManager lvlMan;

    Vector3 point2 = new Vector3(10f, 0, 10f);
    Vector3 point1 = new Vector3(0, 0, 10f);
    Vector3 point3 = new Vector3(-10f, 0, 10f);
    Vector3 point4 = new Vector3(10f, 0, 0);
    Vector3 point5 = new Vector3(-10f, 0, 0);
    Vector3 offset, doorPos;

    public GameObject room, door, storyPoint, challengeNode;
    public GameObject Straight, Diagonal, regDoor, lockDoor;

    private int dir;

    // Use this for initialization
    void Start () {
        GameObject Point;
        int rooms = 1, sideRooms = 1;
        int routeMain = 0;
        int routeSide = 0;
        int sideNum = Random.Range(0,3);
        int ifStory = Random.Range(0, 3);
        bool pointSame = true, roomSelection = false, main = false;
        bool startRoute = false, startDoor = false;
        lvlMan.emptyPoints++;
        door = regDoor;

        if(lvlMan.start)
        {
            ifStory = 1;
            sideNum = 0;
            startRoute = true;
            startDoor = true;
            lvlMan.start = false;
        }

        if(lvlMan.storyPoints <= 3 || lvlMan.storyPoints == 5)
        {
            ifStory = 1;
        }
        if(lvlMan.storyPoints == 4 && lvlMan.trial)
        {
            ifStory = 2;
            lvlMan.trial = false;
        }

        if (ifStory == 1 || lvlMan.emptyPoints >= 3)
        {
            Point = Instantiate(storyPoint, transform.position + new Vector3(0, 0.1f, 0), transform.rotation) as GameObject;
            Point.transform.parent = transform;
            lvlMan.storyPoints++;
            if (lvlMan.emptyPoints >= 2)
            { lvlMan.emptyPoints = 0; }
        }
        else
        {
            Point = Instantiate(challengeNode, transform.position + new Vector3(0, 0.1f, 0), transform.rotation) as GameObject;
            Point.transform.parent = transform;
        }

        while (rooms <= (sideNum+1) && /*lvlMan.roomAmount <= 10*/lvlMan.storyPoints < 8)
        {

            while (roomSelection == false)
            {
                //Main branch
                if (rooms == 1)
                {
                    int route;
                    if (startRoute)
                    { route = 1; }
                    else
                    { route = Random.Range(1, 4); }
                    routeMain = route;
                    PointCheck(route);
                    roomSelection = true;
                    main = true;
                }

                //Side branch
                else
                {
                    
                    if (sideRooms < (sideNum +1))
                    {
                        do
                        {
                            int route = Random.Range(1, 6);
                            if (route == routeMain || route == routeSide)
                            {
                                pointSame = true;
                            }
                            else
                            {
                                PointCheck(route);
                                //room = Side;
                                routeSide = route;
                                pointSame = false;
                                roomSelection = true;
                                sideRooms++;
                                main = false;
                            }
                        } while (pointSame != false);
                    }
                }
            }

            Vector3 pos = transform.position;
            Vector3 newPos = pos + offset;
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, offset);
            GameObject newRoom = Instantiate(room, newPos, rot) as GameObject;
            newRoom.GetComponent<Corridor>().main = main;
            newRoom.GetComponent<Corridor>().dir = dir;
            if (startDoor) { startDoor = false; }
            else
            {
                DoorPick(main);
                GameObject Door = Instantiate(door, pos + doorPos, rot) as GameObject;
                if(door == lockDoor)
                {
                    Door.GetComponent<Door>().locked = true;
                }
                Door.transform.parent = Point.transform;
            }
            
            lvlMan.roomAmount++;
            rooms++;
            roomSelection = false;
        } 
    }
	
    //Function used to select which point to spawn the room
    void PointCheck(int rooms)
    {
        switch (rooms)
        {
            case 1:
                offset = point1;
                room = Straight;
                dir = 1;
                break;
            case 2:
                offset = point2;
                room = Diagonal;
                dir = 2;
                break;
            case 3:
                offset = point3;
                room = Diagonal;
                dir = 3;
                break;
            case 4:
                offset = point4;
                room = Straight;
                dir = 4;
                break;
            case 5:
                offset = point5;
                room = Straight;
                dir = 5;
                break;
        }
    }

    void DoorPick(bool ifmain)
    {
        Vector3 doorPoint2 = new Vector3(3.5f, 2.5f, 3.5f);
        Vector3 doorPoint1 = new Vector3(0, 2.5f, 4.75f);
        Vector3 doorPoint3 = new Vector3(-3.5f, 2.5f, 3.5f);
        Vector3 doorPoint4 = new Vector3(4.75f, 2.5f, 0);
        Vector3 doorPoint5 = new Vector3(-4.75f, 2.5f, 0);
        if (/*ifmain && */lvlMan.keys != 0 &&  lvlMan.keys>lvlMan.doors)
        { 
            int doorRand = Random.Range(0, 3);
            if(doorRand == 1)
            {
                door = lockDoor;
                lvlMan.doors++;
            }
        }
        else
        {
            door = regDoor;
        }

        switch (dir)
        {
            case 1:
                doorPos = doorPoint1;
                break;
            case 2:
                doorPos = doorPoint2;
                break;
            case 3:
                doorPos = doorPoint3;
                break;
            case 4:
                doorPos = doorPoint4;
                break;
            case 5:
                doorPos = doorPoint5;
                break;
        }
    }
}
