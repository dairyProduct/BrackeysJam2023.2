using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateLevelFromRooms : MonoBehaviour
{
    public List<GameObject> NorthSouthRooms;
    public List<GameObject> EastWestRooms;
    public List<GameObject> CenterRooms;
    public List<RoomDoorManager> map;

    public int roomDepth;
    RoomDoorManager currentRoom;
    int currentRoomIndex;

    Vector2 startLocation = new Vector2 (0, 0);

    private void Start()
    {
        GameObject room = Instantiate(CenterRooms[getRandomRoom(CenterRooms.Count)], startLocation, Quaternion.identity);
        currentRoom = room.GetComponent<RoomDoorManager>();
        currentRoomIndex = 0;
        map.Add(currentRoom);
        int iterations = 0;

        while (currentRoomIndex < roomDepth && iterations < roomDepth)
        {
            fillCurrentRoom();
            if(currentRoomIndex < map.Count-1)
            {
                currentRoomIndex++;
                currentRoom = map[currentRoomIndex];
            }
            iterations++;
        }
        blockAllUnusedDoors();
        
    }


    int getRandomRoom(int lengthOfList)
    {
        return Random.Range(0, lengthOfList);
    }

    void fillCurrentRoom()
    {
        RoomDoorManager curr;
        if (currentRoom.hasNorth && !currentRoom.northUsed)
        {
            currentRoom.northUsed = true;
            GameObject room = Instantiate(NorthSouthRooms[getRandomRoom(NorthSouthRooms.Count)], currentRoom.doorNorth.position, Quaternion.identity);
            curr = room.GetComponent<RoomDoorManager>();
            curr.southUsed = true;
            room.transform.position += new Vector3(curr.roomOffsetx, curr.roomOffsety, 0f);
            map.Add(room.GetComponent<RoomDoorManager>());
            
        }
        if (currentRoom.hasEast && !currentRoom.eastUsed)
        {
            currentRoom.eastUsed = true;
            GameObject room = Instantiate(EastWestRooms[getRandomRoom(EastWestRooms.Count)], currentRoom.doorEast.position, Quaternion.identity);
            curr = room.GetComponent<RoomDoorManager>();
            curr.westUsed = true;
            room.transform.position += new Vector3(curr.roomOffsetx, curr.roomOffsety, 0f);
            map.Add(room.GetComponent<RoomDoorManager>());

        }
        if (currentRoom.hasSouth && !currentRoom.southUsed)
        {
            currentRoom.southUsed = true;
            GameObject room = Instantiate(NorthSouthRooms[getRandomRoom(NorthSouthRooms.Count)], currentRoom.doorSouth.position, Quaternion.identity);
            curr = room.GetComponent<RoomDoorManager>();
            curr.northUsed = true;
            room.transform.position += new Vector3(-curr.roomOffsetx, -curr.roomOffsety, 0f);
            map.Add(room.GetComponent<RoomDoorManager>());
        }
        if (currentRoom.hasWest && !currentRoom.westUsed)
        {
            currentRoom.westUsed = true;
            GameObject room = Instantiate(EastWestRooms[getRandomRoom(EastWestRooms.Count)], currentRoom.doorWest.position, Quaternion.identity);
            curr = room.GetComponent<RoomDoorManager>();
            curr.eastUsed = true;
            room.transform.position += new Vector3(-curr.roomOffsetx, -curr.roomOffsety, 0f);
            map.Add(room.GetComponent<RoomDoorManager>());
        }
    }


    void blockAllUnusedDoors()
    {
        foreach (RoomDoorManager room in map)
        {
            room.blockUnusedDoors();
        }
    }


}
