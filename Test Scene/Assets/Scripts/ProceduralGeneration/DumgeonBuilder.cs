using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DumgeonBuilder : MonoBehaviour
{

    public Tilemap tileMap;
    public Tile[] testTile;
    public Tile anothertest;

    public int startX;
    public int startY;
    public int dungeonSize;
    int[,] dungeonMatrix;

    private bool done = true;

    private flowManager testFlowManager;


    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && done == true)
        {
            done = false;

            tileMap.ClearAllTiles();
            dungeonMatrix = new int[dungeonSize, dungeonSize];

            testFlowManager = new flowManager();
            testFlowManager.initializeWater1Flow(200, 200);

            iterateFlow(testFlowManager.baseFlow);

            interpretDungeon();
            done = true;
        }
    }

    void iterateFlow(flow selectedFlow)
    {
        List<roomVert> flowRooms = selectedFlow.rooms;

        flowRooms[0].discovered = true;
        addTemplateToMatrix(flowRooms[0]);

        foreach (roomVert currentRoom in flowRooms)
        {
            if (currentRoom.discovered)
            {
                foreach (roomVert neighborRoom in currentRoom.neighbors)
                {
                    if (!neighborRoom.discovered)
                    {
                        bool set = setLocationForNewRoom(neighborRoom, currentRoom);
                        if (set)
                        {
                            neighborRoom.discovered = true;
                        }
                    }
                }
            }
        }
    }

    bool setLocationForNewRoom(roomVert newRoom, roomVert oldRoom)
    {
        bool placed = false;

        int[] key = { 2, 3, 0, 1 }; ////associates left with right and top with bottom when checking

        List<int> availableSides = new List<int>();

        int count = 0;

        while (count < 6 && !placed)
        {
            availableSides = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                if (oldRoom.availableDoorDirections[i] && newRoom.availableDoorDirections[key[i]])
                {
                    availableSides.Add(i);
                }
            }

            int selectedSide = -1;

            //finds available side (references the newRoom not the old room, uses key to know which side to access for old)
            if (availableSides.Count == 1)
            {
                selectedSide = availableSides[0];
            }
            else if (availableSides.Count > 1)
            {
                selectedSide = availableSides[Random.Range(0, availableSides.Count)];
            }

            //actual placement
            if (selectedSide >= 0)
            {
                int[] oldDoorSelection;
                int[] newDoorSelection;

                bool found = false;
                int oldSelection = -1;
                int newSelection = -1;

                if (selectedSide == 0) // up
                {
                    if (oldRoom.possibleTopDoorLocations.Count > 1 && newRoom.possibleBottomDoorLocations.Count > 1)
                    {

                        while (!found)
                        {
                            oldSelection = Random.Range(0, oldRoom.possibleTopDoorLocations.Count - 1);
                            newSelection = Random.Range(0, newRoom.possibleBottomDoorLocations.Count - 1);
                            if (oldSelection + 1 < oldRoom.possibleTopDoorLocations.Count && newSelection + 1 < newRoom.possibleBottomDoorLocations.Count)
                            {
                                found = true;
                            }
                        }

                        oldRoom.Door2Wall2Tile(oldSelection, 0);
                        newRoom.Door2Wall2Tile(newSelection, 2);
                    }

                    oldDoorSelection = oldRoom.possibleTopDoorLocations[0];
                    newDoorSelection = newRoom.possibleBottomDoorLocations[0];

                    newRoom.xLocation = oldRoom.xLocation + oldDoorSelection[1] - newDoorSelection[1];
                    newRoom.yLocation = oldRoom.yLocation + oldRoom.structure.GetLength(0);
                }
                else if (selectedSide == 1) // right
                {
                    if (oldRoom.possibleRightDoorLocations.Count > 1 && newRoom.possibleLeftDoorLocations.Count > 1)
                    {
                        while (!found)
                        {
                            oldSelection = Random.Range(0, oldRoom.possibleRightDoorLocations.Count - 1);
                            newSelection = Random.Range(0, newRoom.possibleLeftDoorLocations.Count - 1);
                            if (oldSelection + 1 < oldRoom.possibleRightDoorLocations.Count && newSelection + 1 < newRoom.possibleLeftDoorLocations.Count)
                            {
                                found = true;
                            }
                        }

                        oldRoom.Door2Wall2Tile(oldSelection, 1);
                        newRoom.Door2Wall2Tile(newSelection, 3);
                    }

                    oldDoorSelection = oldRoom.possibleRightDoorLocations[0];
                    newDoorSelection = newRoom.possibleLeftDoorLocations[0];

                    newRoom.xLocation = oldRoom.xLocation + oldRoom.structure.GetLength(0);
                    newRoom.yLocation = oldRoom.yLocation - oldDoorSelection[0] + newDoorSelection[0];
                }
                else if (selectedSide == 2) // down
                {
                    if (oldRoom.possibleBottomDoorLocations.Count > 1 && newRoom.possibleTopDoorLocations.Count > 1)
                    {
                        while (!found)
                        {
                            oldSelection = Random.Range(0, oldRoom.possibleBottomDoorLocations.Count - 1);
                            newSelection = Random.Range(0, newRoom.possibleTopDoorLocations.Count - 1);
                            if (oldSelection + 1 < oldRoom.possibleBottomDoorLocations.Count && newSelection + 1 < newRoom.possibleTopDoorLocations.Count)
                            {
                                found = true;
                            }
                        }

                        oldRoom.Door2Wall2Tile(oldSelection, 2);
                        newRoom.Door2Wall2Tile(newSelection, 0);
                    }

                    oldDoorSelection = oldRoom.possibleBottomDoorLocations[0];
                    newDoorSelection = newRoom.possibleTopDoorLocations[0];

                    newRoom.xLocation = oldRoom.xLocation + oldDoorSelection[1] - newDoorSelection[1];
                    newRoom.yLocation = oldRoom.yLocation - oldRoom.structure.GetLength(1);
                }
                else // left
                {
                    if (oldRoom.possibleLeftDoorLocations.Count > 1 && newRoom.possibleRightDoorLocations.Count > 1)
                    {
                        while (!found)
                        {
                            oldSelection = Random.Range(0, oldRoom.possibleLeftDoorLocations.Count - 1);
                            newSelection = Random.Range(0, newRoom.possibleRightDoorLocations.Count - 1);
                            if (oldSelection + 1 < oldRoom.possibleLeftDoorLocations.Count && newSelection + 1 < newRoom.possibleRightDoorLocations.Count)
                            {
                                found = true;
                            }
                        }

                        oldRoom.Door2Wall2Tile(oldSelection, 3);
                        newRoom.Door2Wall2Tile(newSelection, 1);
                    }
                    oldDoorSelection = oldRoom.possibleLeftDoorLocations[0];
                    newDoorSelection = newRoom.possibleRightDoorLocations[0];

                    newRoom.xLocation = oldRoom.xLocation - oldRoom.structure.GetLength(0);
                    newRoom.yLocation = oldRoom.yLocation - oldDoorSelection[0] + newDoorSelection[0];
                }

                bool clear = checkCollisions(newRoom);

                if (clear)
                {
                    oldRoom.ConfirmDoor(true, selectedSide);
                    newRoom.ConfirmDoor(true, key[selectedSide]);
                    addTemplateToMatrix(oldRoom);
                    addTemplateToMatrix(newRoom);
                    placed = true;
                }
                else
                {
                    oldRoom.ConfirmDoor(false, selectedSide);
                    newRoom.ConfirmDoor(false, key[selectedSide]);
                    placed = false;
                    count++;
                }
            }
        }

        if (!placed)
        {
            Debug.Log("failed to place");
        }

        return placed;
    }

    bool checkCollisions(roomVert selectedRoom)
    {
        bool clear = true;

        int templateXSize = selectedRoom.structure.GetLength(1);
        int templateYSize = selectedRoom.structure.GetLength(0);

        for (int x = templateXSize - 1; x >= 0; x--)
        {
            for (int y = templateYSize - 1; y >= 0; y--)
            {
                if (dungeonMatrix[selectedRoom.xLocation + x, selectedRoom.yLocation + templateYSize - 1 - y] != 0 && selectedRoom.structure[y, x] != 0)
                {
                    clear = false;
                }
            }
        }

        return clear;
    }

    void addTemplateToMatrix(roomVert selectedRoom)
    {
        int templateXSize = selectedRoom.structure.GetLength(1);
        int templateYSize = selectedRoom.structure.GetLength(0);

        for (int x = templateXSize - 1; x >= 0; x--)
        {
            for (int y = templateYSize - 1; y >= 0; y--)
            {
                // change the order if we want to check less
                if (selectedRoom.structure[y, x] != 0 && selectedRoom.structure[y, x] != 2 )
                {
                    dungeonMatrix[selectedRoom.xLocation + x, selectedRoom.yLocation + templateYSize - 1 - y] = selectedRoom.structure[y, x];
                }
                else if (selectedRoom.structure[y, x] == 2)
                {
                    dungeonMatrix[selectedRoom.xLocation + x, selectedRoom.yLocation + templateYSize - 1 - y] = 1;
                }
            }
        }
    }

    void interpretDungeon()
    {
        Vector3Int cords = new Vector3Int(0, 0, 0);

        for (int x = 0; x < dungeonSize; x++)
        {
            cords.x = x;
            for (int y = 0; y < dungeonSize; y++)
            {
                if (dungeonMatrix[x, y] != 0)
                {
                    cords.y = y;
                    tileMap.SetTile(cords, testTile[dungeonMatrix[x, y]]);
                }
            }
        }
    }

}
/*
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
ALLISON WAS HERE
*/
