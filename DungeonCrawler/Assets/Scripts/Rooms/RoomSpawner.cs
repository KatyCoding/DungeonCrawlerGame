using System;
using UnityEngine;
using System.Collections.Generic;

public class RoomSpawner : MonoBehaviour
{
    
    private static RoomSpawner instance;
    public RoomSequence roomSequence;
    private static RoomPrefabContainer roomPrefabs;
    private int sequenceProgress = -1;
    private Room currentRoom;

    private void Awake()
    {
        instance = this;
        roomPrefabs = Resources.Load("RoomPrefabContainer") as RoomPrefabContainer;
    }

    private void Start()
    {
        SpawnNextRoom();
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
            return;
        }

        var room = instance.roomSequence.Rooms[++instance.sequenceProgress];
        if (instance.currentRoom)
            DestroyImmediate(instance.currentRoom.gameObject);
        instance.currentRoom = Instantiate(GetRoomPrefab(room.Theme), instance.transform);
        instance.currentRoom.SetRoomData(room);
        instance.currentRoom.EnterRoom();
    }

    public static Room GetRoomPrefab(Room.RoomTheme theme)
    {
        switch (theme)
        {
            case Room.RoomTheme.Fire:
                return roomPrefabs.Fire;
            case Room.RoomTheme.Water:
                return roomPrefabs.Water;
            case Room.RoomTheme.Snow:
                return roomPrefabs.Snow;
            case Room.RoomTheme.Swamp:
                return roomPrefabs.Swamp;
            case Room.RoomTheme.Cave:
                return roomPrefabs.Cave;
            case Room.RoomTheme.Dungeon:
                return roomPrefabs.Dungeon;
            case Room.RoomTheme.Forest:
                return roomPrefabs.Forest;
        }

        return null;
    }
}