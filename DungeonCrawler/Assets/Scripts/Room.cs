using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
    //need to figure out where to inject roomdata through the room spawner
    //spawner has prefab ref, but not data ref, rooms shouldn't know data beforehand
    //maybe roomdata actually refs the prefab instead and the spawner just refs the data?
    protected RoomData roomData;
    public void SetRoomData(RoomData data)
    {
        roomData = data;
    }
    public virtual void EnterRoom()
    {
        SpawnEnemy();
    }
    protected virtual void SpawnEnemy()
    {
        int enemy = Random.Range(0, roomData.PossibleEnemies.Count);
        Instantiate(roomData.PossibleEnemies[enemy], transform);
    }
}

[CreateAssetMenu(fileName = "Room", menuName = "Room", order = 1)]
public class RoomData :ScriptableObject
{
    public List<GameObject> PossibleEnemies = new List<GameObject>();
    
}
