using UnityEngine;

[CreateAssetMenu(fileName = "RoomPrefabContainer", menuName = "Scriptable Objects/RoomPrefabContainer")]
public class RoomPrefabContainer : ScriptableObject
{
    public Room Fire;
    public Room Snow;
    public Room Swamp;
    public Room Cave;
    public Room Dungeon;
    public Room Water;
    public Room Forest;
}
