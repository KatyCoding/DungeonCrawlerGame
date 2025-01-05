using System;
using UnityEngine;
using System.Collections.Generic;
public class RoomSpawner : MonoBehaviour
{
    private static RoomSpawner instance;
    public RoomSequence roomSequence;
    private int sequenceProgress = -1;
    private Room currentRoom;
    private void Awake()
    {
        instance = this;
    }
[ContextMenu("Force Next Room")]
    private void ForceSpawn()
    {
        SpawnNextRoom();
    }
    public static void SpawnNextRoom()
    {
        if (instance.sequenceProgress == instance.roomSequence.Rooms.Count - 1)
        {
            Debug.LogError("No more rooms to spawn");
        }
        
        var room = instance.roomSequence.Rooms[++instance.sequenceProgress];
        DestroyImmediate(instance.currentRoom);
        instance.currentRoom = Instantiate(room, instance.transform);
        instance.currentRoom.EnterRoom();
        
    }
}
