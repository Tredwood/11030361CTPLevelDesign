using UnityEngine;
using System.Collections;

//Used to keep track of variables that span across all instanced objects

public class LevelManager : MonoBehaviour
{

    public int emptyPoints;
    public int storyPoints;
    public int roomAmount;
    public int keys, doors;
    public int keysHeld;
    public bool start;
    public bool hasWeapon = false;
    public bool hasUpgrade = false;
    public bool trial = true;
    
}