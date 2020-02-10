using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flow
{
    public List<roomVert> rooms;
    public List<roomVert> breadthSorted;

    public flow()
    {
        rooms = new List<roomVert> ();
        breadthSorted = new List<roomVert> ();
    }

    public flow(roomVert startRoom)
    {
        rooms = new List<roomVert> ();
        breadthSorted = new List<roomVert> ();
        rooms.Add(startRoom);
    }

    public void addStart(roomVert startRoom)
    {
        rooms.Add(startRoom);
    }

    public void addNeighbor(roomVert from, roomVert to)
    {
        if (rooms.Contains(from))
        {
            rooms.Add(to);
            from.addNeighbor(to);
        }
    }

    public void printNodesBreadth()
    {
        Queue<roomVert> roomQueue = new Queue<roomVert>();
        rooms[0].discovered = true;
        roomQueue.Enqueue(rooms[0]);
        breadthSorted.Add(rooms[0]);
        while (roomQueue.Count != 0)
        {
            roomVert currentRoom = roomQueue.Dequeue();
            breadthSorted.Add(currentRoom);
            foreach (roomVert adjacentRoom in currentRoom.neighbors)
            {
                if (!adjacentRoom.discovered)
                {
                    roomQueue.Enqueue(adjacentRoom);
                }
            }
        }
        foreach(roomVert discoverRoom in rooms)
        {
            discoverRoom.discovered = false;
        }
        
    }

}