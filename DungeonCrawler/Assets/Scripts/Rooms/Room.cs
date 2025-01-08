using UnityEngine;
using System.Collections.Generic;

public class Room : MonoBehaviour
{
   [HideInInspector] public List<EnemyBehavior> enemies;
    public enum RoomTheme
    {
        Fire,
        Snow,
        Swamp,
        Cave,
        Dungeon,
        Water,
        Forest,
        
    }
    
    protected RoomData roomData;
    public void SetRoomData(RoomData data)
    {
        roomData = data;
    }
    public virtual void EnterRoom()
    {
        GameMaster.CurrentRoom = this;
        SpawnEnemy();
    }
    protected virtual void SpawnEnemy()
    {
        int rand = Random.Range(0, roomData.PossibleEnemies.Count);
        var enemy = Instantiate(roomData.PossibleEnemies[rand], transform);
        enemies.Add(enemy);
       //TODO not this
        enemy.transform.position -= Vector3.forward * 3;
        enemy.OnDeath += EnemyDied;
    }

    void EnemyDied(EntityBehavior enemy)
    {
        enemies.Remove(enemy as EnemyBehavior);
        if (enemies.Count == 0)
        {
            RoomSpawner.SpawnNextRoom();
        }
    }
}

