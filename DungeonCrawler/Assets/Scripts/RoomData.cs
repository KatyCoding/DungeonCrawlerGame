using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Room", menuName = "Room", order = 1)]
public class RoomData :ScriptableObject
{
    public Room.RoomTheme Theme;
    public List<EnemyBehavior> PossibleEnemies = new List<EnemyBehavior>();
    
}