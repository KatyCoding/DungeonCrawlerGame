using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Room", menuName = "Room", order = 1)]
public class Room :ScriptableObject
{
    public List<GameObject> PossibleEnemies;
    
}
