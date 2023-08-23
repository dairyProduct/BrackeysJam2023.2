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

    Vector2 playerStart;


    private void Start()
    {
        generateRoom(levelHeight, levelWidth);
        playerStart = new Vector2(levelWidth/2, levelHeight/2);
        Instantiate(player, playerStart, Quaternion.identity);
        generateScatter(levelHeight, levelWidth);
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
        int generateThreshold = 19; //5%
        int generateMax = 21;
        bool justGenerated = false;
        for (int i = 1; i < roomHeight - 1; i++)
        {
            for (int j = 1; j < roomWidth - 1; j++)
            {
                shouldGenerate = Random.Range(1, generateMax);
                if (shouldGenerate > generateThreshold && !justGenerated && scatterGenerated < maxScatter && !(new Vector2(i,j) == playerStart))
                {
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


}
