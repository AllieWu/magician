using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowManager
{

    public flow baseFlow;

    public flowManager()
    {
        baseFlow = new flow();
    }

    public void initializeWater1Flow(int startX, int startY)
    {
        roomTemplates templates = new roomTemplates();
        roomVert newRoom = new roomVert(templates.startRoom, startX, startY);
        baseFlow.addStart(newRoom);

        roomVert newAddRoomTest = new roomVert(templates.addRoom);
        Debug.Log(newAddRoomTest.structure);
        baseFlow.addNeighbor(newRoom, newAddRoomTest);
        roomVert newAddRoomTest1 = new roomVert(templates.Lexample1);
        baseFlow.addNeighbor(newAddRoomTest, newAddRoomTest1);
        roomVert newAddRoomTest2 = new roomVert(templates.plusExample1);
        baseFlow.addNeighbor(newAddRoomTest, newAddRoomTest2);
        roomVert newAddRoomTest3 = new roomVert(templates.addRoom);
        baseFlow.addNeighbor(newAddRoomTest, newAddRoomTest3);
        roomVert newAddRoomTest4 = new roomVert(templates.plusExample1);
        baseFlow.addNeighbor(newAddRoomTest3, newAddRoomTest4);
    }

    public void initializeLoopFlow(int startX, int startY)
    {
        roomTemplates templates = new roomTemplates();
        roomVert newRoom = new roomVert(templates.startRoom, startX, startY);
        baseFlow.addStart(newRoom);

        roomVert newAddRoomTest = new roomVert(templates.addRoom);
        Debug.Log(newAddRoomTest.structure);
        baseFlow.addNeighbor(newRoom, newAddRoomTest);
        roomVert newAddRoomTest1 = new roomVert(templates.Lexample1);
        baseFlow.addNeighbor(newAddRoomTest, newAddRoomTest1);
        roomVert newAddRoomTest2 = new roomVert(templates.plusExample1);
        baseFlow.addNeighbor(newAddRoomTest, newAddRoomTest2);
        roomVert newAddRoomTest3 = new roomVert(templates.addRoom);
        baseFlow.addNeighbor(newAddRoomTest, newAddRoomTest3);
        roomVert newAddRoomTest4 = new roomVert(templates.plusExample1);
        baseFlow.addNeighbor(newAddRoomTest3, newAddRoomTest4);
        // roomVert newLoopRoom = new roomVert(true);
    }

}