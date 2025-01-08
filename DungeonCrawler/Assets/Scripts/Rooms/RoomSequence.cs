using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "New Room Sequence", menuName = "Room Sequence")]
public class RoomSequence : ScriptableObject
{
    public List<RoomData> Rooms;
}
