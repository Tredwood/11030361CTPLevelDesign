using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {
    [SerializeField]
    LevelManager lvlMan;

    public GameObject weapon, weapon2, mainRoom, oldMan, dummy, enemy, portal, boss;
    public bool complete = false;
    int point;

    void Start ()
    {
        point = lvlMan.storyPoints - 1;
        StoryPick(point);
        
	}
	
	void Update () {
	if(complete)
        {
            StoryFinish();
        }
	}

    void StoryPick(int i)
    {
        
        switch(i)
        {
            
            case 1:StoryPoint1();
                break;
            case 2:
                StoryPoint2();
                break;
            case 3:
                StoryPoint3();
                break;
            case 4:
                StoryPoint4();
                break;
            case 5:
                StoryPoint5();
                break;
            case 6:
                StoryPoint6();
                break;
            case 7:
                StoryPoint7();
                break;
        }
    }

    void StoryPoint1()
    {
        OldMan();
        GameObject Weapon = Instantiate(weapon, transform.position + new Vector3(0, 1f, 0), transform.rotation) as GameObject;
        Weapon.transform.parent = transform;

    }

    void StoryPoint2()
    {
        OldMan();
        GameObject Dummy = Instantiate(dummy, transform.position + new Vector3(0, 0.75f, 0), transform.rotation) as GameObject;
        Dummy.transform.parent = transform;
    }

    void StoryPoint3()
    {
        OldMan();
        Instantiate(mainRoom, transform.position + new Vector3(0, -20f, 0), transform.rotation);
    }
    void StoryPoint4()
    {
        GameObject Boss = Instantiate(boss, transform.position + new Vector3(0, 1.5f, 0), transform.rotation) as GameObject;
        Boss.transform.parent = transform;
    }
    void StoryPoint5()
    {
        GameObject Weapon2 = Instantiate(weapon2, transform.position + new Vector3(0, 1f, 0), transform.rotation) as GameObject;
        Weapon2.transform.parent = transform;
    }

    void StoryPoint6()
    {
        GameObject Boss = Instantiate(boss, transform.position + new Vector3(0, 1.5f, 0), transform.rotation)as GameObject;
        Boss.transform.parent = transform;
    }

    void StoryPoint7()
    {
        Instantiate(portal, transform.position, transform.rotation);
    }

    void StoryFinish()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<Door>().open = true;
        }
        complete = false;
    }

    void OldMan()
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, new Vector3(1, 0.75f, 1));
        Instantiate(oldMan, transform.position + new Vector3(1, 0.5f, 1), transform.rotation);
    }
}
