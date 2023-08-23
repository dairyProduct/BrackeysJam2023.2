using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int levelHeight;
    public int levelWidth;
    //float levelWallOffset = 0.5f;

    public GameObject levelWall;
    public GameObject levelDoor;
    public GameObject player;
    public GameObject[] scatter;
    public List<Vector2> spawnLocations;
    public GameObject EnemySpawner;
    public int numMonsterSpawners = 2;

    Vector2 playerStart;


    private void Start()
    {
        spawnLocations = new List<Vector2>();
        generateRoom(levelHeight, levelWidth);
        setPlayerStart();
        generateScatter(levelHeight, levelWidth);
        generateMonsterSpawners();
    }

    private void generateRoom(int roomHeight, int roomWidth)
    {
        int i = 0;
        for(i = 0; i < roomHeight; i++)
        {
            Instantiate(levelWall, new Vector2(roomWidth, i), Quaternion.identity);
        }
        for (i = 0; i < roomHeight; i++)
        {
            Instantiate(levelWall, new Vector2(0, i), Quaternion.identity);
        }
        for(i = 0; i < roomWidth; i++)
        {
            Instantiate(levelWall, new Vector2(i, roomHeight), Quaternion.identity);
        }
        for (i = 0; i < roomWidth; i++)
        {
            Instantiate(levelWall, new Vector2(i, 0), Quaternion.identity);
        }
        Instantiate(levelWall, new Vector2(roomWidth, roomHeight), Quaternion.identity);  
    }


    private void generateScatter(int roomHeight, int roomWidth, int maxScatter = 6)
    {
        int scatterGenerated = 0;
        int shouldGenerate;
        int generateThreshold = 48; //2%
        int generateMax = 51;
        bool justGenerated = false;
        for (int i = 1; i < roomWidth - 1; i++)
        {
            for (int j = 1; j < roomHeight - 1; j++)
            {
                shouldGenerate = Random.Range(1, generateMax);
                Vector2 spot = new Vector2(i, j);
                if (shouldGenerate > generateThreshold && !justGenerated && scatterGenerated < maxScatter && !checkIfLocationUsed(spot))
                {
                    updateLocationsUsed(spot);
                    int whichScatter = Random.Range(0, scatter.Length);
                    Instantiate(scatter[whichScatter], new Vector2(i, j), Quaternion.identity);
                    justGenerated = true;
                    scatterGenerated++;
                }
                else
                {
                    justGenerated = false;
                }
            }
        }
    }


    private void generateMonsterSpawners()
    {
        iterateMapAndSpawnStuff(EnemySpawner, levelHeight, levelWidth, numMonsterSpawners); //probably should be like based on levelDepth?
    }

    private bool checkIfLocationUsed(Vector2 location)
    {
        foreach (Vector2 spawn in spawnLocations)
        {
            if (location.x == spawn.x && location.y == spawn.y)
            {
                return true;
            }
        }

        return false;
    }

    private void updateLocationsUsed(Vector2 location)
    {
        spawnLocations.Add(location);
    }

    private void setPlayerStart()
    {
        playerStart = new Vector2(levelWidth / 2, levelHeight / 2);
        Instantiate(player, playerStart, Quaternion.identity);
        updateLocationsUsed(playerStart);
    }


    private void iterateMapAndSpawnStuff(GameObject stuff, int roomHeight, int roomWidth, int maxStuff = 6)
    {
        int stuffGenerated = 0;
        int shouldGenerate;
        int generateThreshold = 48; //2%
        int generateMax = 52;
        bool justGenerated = false;
        for (int i = 1; i < roomWidth - 1; i++)
        {
            for (int j = 1; j < roomHeight - 1; j++)
            {
                shouldGenerate = Random.Range(1, generateMax);
                Vector2 spot = new Vector2(i, j);
                if (shouldGenerate > generateThreshold && !justGenerated && stuffGenerated < maxStuff && !checkIfLocationUsed(spot))
                {
                    updateLocationsUsed(spot);
                    int whichScatter = Random.Range(0, scatter.Length);
                    Instantiate(stuff, new Vector2(i, j), Quaternion.identity);
                    justGenerated = true;
                    stuffGenerated++;
                }
                else
                {
                    justGenerated = false;
                }
            }
        }
    }

}
