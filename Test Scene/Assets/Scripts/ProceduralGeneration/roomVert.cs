using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomVert
{
    public bool isLoop = false;
    public List<roomVert> neighbors = new List<roomVert>();

    public int[,] structure;

    public bool[] availableDoorDirections = { false, false, false, false }; //// [0] - up // [1] - right // [2] - down // [3] - left

    public List<int[]> TopDoorLocations = new List<int[]>();
    public List<int[]> BottomDoorLocations = new List<int[]>();
    public List<int[]> RightDoorLocations = new List<int[]>();
    public List<int[]> LeftDoorLocations = new List<int[]>();

    public List<int[]> possibleTopDoorLocations = new List<int[]>();
    public List<int[]> possibleBottomDoorLocations = new List<int[]>();
    public List<int[]> possibleRightDoorLocations = new List<int[]>();
    public List<int[]> possibleLeftDoorLocations = new List<int[]>();

    public List<int[]> bufferTopDoorLocations = new List<int[]>();
    public List<int[]> bufferBottomDoorLocations = new List<int[]>();
    public List<int[]> bufferRightDoorLocations = new List<int[]>();
    public List<int[]> bufferLeftDoorLocations = new List<int[]>();

    public int xLocation;
    public int yLocation;
    public int xSize;
    public int ySize;

    public roomVert(int[,] structure_, int xLocation_, int yLocation_)
    {
        constructRoomObject(structure_, xLocation_, yLocation_);
    }

    public roomVert(int[,] structure_)
    {
        constructRoomObject(structure_, 20, 20);
    }

    public roomVert(bool isItLoop)
    {
        isLoop = isItLoop;
    }

    void constructRoomObject(int[,] structure_, int xLocation_, int yLocation_)
    {
        structure = new int[structure_.GetLength(0), structure_.GetLength(1)];
        for(int x = 0; x < structure_.GetLength(1); x++)
        {
            for(int y = 0; y < structure_.GetLength(0); y++)
            {
                structure[y, x] = structure_[y, x];
            }
        }
        xLocation = xLocation_;
        yLocation = yLocation_;
        xSize = structure.GetLength(1);
        ySize = structure.GetLength(0);

        int yBottomLevel = structure.GetLength(0) - 1;
        for (int x = 0; x < structure.GetLength(1); x++)
        {
            if (structure[0, x] == 2)
            {
                availableDoorDirections[0] = true;
                int[] newPair = { 0, x };
                possibleTopDoorLocations.Add(newPair);
            }

            if (structure[yBottomLevel, x] == 2)
            {
                availableDoorDirections[2] = true;
                int[] newPair = { yBottomLevel, x };
                possibleBottomDoorLocations.Add(newPair);
            }
        }

        for (int y = 0; y < structure.GetLength(0); y++)
        {
            int xRightLevel = structure.GetLength(1) - 1;
            if (structure[y, 0] == 2)
            {
                availableDoorDirections[3] = true;
                int[] newPair = { y, 0 };
                possibleLeftDoorLocations.Add(newPair);
            }

            if (structure[y, xRightLevel] == 2)
            {
                availableDoorDirections[1] = true;
                int[] newPair = { y, xRightLevel };
                possibleRightDoorLocations.Add(newPair);
            }
        }
        bufferTopDoorLocations = possibleTopDoorLocations;
        bufferRightDoorLocations = possibleRightDoorLocations;
        bufferBottomDoorLocations = possibleBottomDoorLocations;
        bufferLeftDoorLocations = possibleLeftDoorLocations;
    }

    public void addNeighbor(roomVert newNeighbor)
    {
        if (newNeighbor != null)
        {
            neighbors.Add(newNeighbor);
        }
    }

    public void Door2Wall2Tile(int selection, int directionSelection)
    {
        List<int[]> newDoorLocations = new List<int[]>();

        if (directionSelection == 0) //up
        {
            newDoorLocations.Add(possibleTopDoorLocations[selection]);
            newDoorLocations.Add(possibleTopDoorLocations[selection + 1]);
            possibleTopDoorLocations = newDoorLocations;
        }
        else if (directionSelection == 1) //right
        {
            newDoorLocations.Add(possibleRightDoorLocations[selection]);
            newDoorLocations.Add(possibleRightDoorLocations[selection + 1]);
            possibleRightDoorLocations = newDoorLocations;
        }
        else if (directionSelection == 2) //down
        {
            newDoorLocations.Add(possibleBottomDoorLocations[selection]);
            newDoorLocations.Add(possibleBottomDoorLocations[selection + 1]);
            possibleBottomDoorLocations = newDoorLocations;
        }
        else //left
        {
            newDoorLocations.Add(possibleLeftDoorLocations[selection]);
            newDoorLocations.Add(possibleLeftDoorLocations[selection + 1]);
            possibleLeftDoorLocations = newDoorLocations;
        }
    }

    public void ConfirmDoor(bool confirmed, int selectedSide)
    {
        if (confirmed)
        {
            if (selectedSide == 0)
            {
                TopDoorLocations = possibleTopDoorLocations;
                foreach (int[] location in bufferTopDoorLocations)
                {
                    structure[location[0], location[1]] = 1;
                }
                foreach (int[] location in TopDoorLocations)
                {
                    structure[location[0], location[1]] = 6;
                }
            }
            else if (selectedSide == 1)
            {
                RightDoorLocations = possibleRightDoorLocations;
                foreach (int[] location in bufferRightDoorLocations)
                {
                    structure[location[0], location[1]] = 1;
                }
                foreach (int[] location in RightDoorLocations)
                {
                    structure[location[0], location[1]] = 6;
                }
            }
            else if (selectedSide == 2)
            {
                BottomDoorLocations = possibleBottomDoorLocations;
                foreach (int[] location in bufferBottomDoorLocations)
                {
                    structure[location[0], location[1]] = 1;
                }
                foreach (int[] location in BottomDoorLocations)
                {
                    structure[location[0], location[1]] = 6;
                }
            }
            else
            {
                LeftDoorLocations = possibleLeftDoorLocations;
                foreach (int[] location in bufferLeftDoorLocations)
                {
                    structure[location[0], location[1]] = 1;
                }
                foreach (int[] location in LeftDoorLocations)
                {
                    structure[location[0], location[1]] = 6;
                }
            }
        }
        else
        {
            if (selectedSide == 0)
            {
                possibleTopDoorLocations = bufferTopDoorLocations;
            }
            else if (selectedSide == 1)
            {
                possibleRightDoorLocations = bufferRightDoorLocations;
            }
            else if (selectedSide == 2)
            {
                possibleBottomDoorLocations = bufferBottomDoorLocations;
            }
            else
            {
                possibleLeftDoorLocations = bufferLeftDoorLocations;
            }
        }
    }

    //helpfulL values that aren't used for the class itself
    public bool discovered;
}