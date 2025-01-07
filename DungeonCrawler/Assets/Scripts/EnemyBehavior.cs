using System;
using UnityEngine;

public class EnemyBehavior : EntityBehavior
{
    public override void Update()
    {
        base.Update();
        if (mainAttackReady)
            MainAttack(GameMaster.PlayerCharacters[0]);

    }
    
    
}
