using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorManager : MonoBehaviour
{
    public GameObject doorBlock;

    public Transform doorNorth;
    public Transform doorSouth;
    public Transform doorEast;
    public Transform doorWest;

    public bool northUsed;
    public bool southUsed;
    public bool eastUsed;
    public bool westUsed;

    public bool hasNorth;
    public bool hasSouth;
    public bool hasEast;
    public bool hasWest;

    public bool isFull;

    public float roomOffsetx;
    public float roomOffsety;

    public Transform takeDoor(doorOrder which)
    {
        if(which == doorOrder.North)
        {
            northUsed = true;
            return doorNorth;
        }
        if (which == doorOrder.East)
        {
            eastUsed = true;
            return doorEast;
        }
        if (which == doorOrder.South)
        {
            southUsed = true;
            return doorSouth;
        }
        else //has to be west
        {
            westUsed = true;
            return doorWest;
        }

    }

    public void blockUnusedDoors()
    {
        //spawn stuff in the doors that aren't marked as used, so the map is "finished"
        if(!northUsed)
        {
            Instantiate(doorBlock, doorNorth);
        }
        if (!eastUsed)
        {
            Instantiate(doorBlock, doorEast);
        }
        if (!southUsed)
        {
            Instantiate(doorBlock, doorSouth);
        }
        if (!westUsed)
        {
            Instantiate(doorBlock, doorWest);
        }
    }

}


public enum doorOrder
{
    North,
    East,
    South,
    West
};
