using UnityEngine;
using System.Collections;

public class Generation : MonoBehaviour
{
    [SerializeField] LevelManager lvlMan;

    Vector3 point2 = new Vector3(2f, 0, 2f);
    Vector3 point1 = new Vector3(0, 0, 2f);
    Vector3 point3 = new Vector3(-2f, 0, 2f);
    Vector3 point4 = new Vector3(2f, 0, 0);
    Vector3 point5 = new Vector3(-2f, 0, 0);
    Vector3 offset;

    public GameObject room, storyPoint, challengeNode;
    public GameObject Main, Side;

    // Use this for initialization
    void Start () {
        int rooms = 1, sideRooms = 1;
        int routeMain = 0;
        int routeSide = 0;
        int sideNum = Random.Range(0,3);
        int ifStory = Random.Range(0, 2);
        bool pointSame = true, roomSelection = false, main = false;
         
        while (rooms <= (sideNum+1) && lvlMan.storyPoints < 6)
        {

            while (roomSelection == false)
            {
                //Main branch
                if (rooms == 1)
                {
                    //Debug.Log(rooms);
                    int route = Random.Range(1, 4);
                    routeMain = route;
                    PointCheck(route);
                    room = Main;
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
                                room = Side;
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
            if (main) { lvlMan.emptyPoints++; }
            if ((main && ifStory == 1) || (main&&lvlMan.emptyPoints >= 3))
            {
                GameObject story = Instantiate(storyPoint, newPos+new Vector3(0,0.1f,0), rot) as GameObject;
                //story.transform.parent = newRoom.transform;
                main = false;
                lvlMan.storyPoints++;
                Debug.Log(lvlMan.emptyPoints);
                if(lvlMan.emptyPoints >= 2)
                { lvlMan.emptyPoints = 0; }
            }
            else
            {
                GameObject challenge = Instantiate(challengeNode, newPos + new Vector3(0, 0.1f, 0), rot) as GameObject;
                //challenge.transform.parent = newRoom.transform;
            }
            rooms++;
            roomSelection = false;
        } 
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    //Function used to select which point to spawn the room
    void PointCheck(int rooms)
    {
        switch (rooms)
        {
            case 1:
                offset = point1;
                break;
            case 2:
                offset = point2;
                break;
            case 3:
                offset = point3;
                break;
            case 4:
                offset = point4;
                break;
            case 5:
                offset = point5;
                break;
        }
    }
}
