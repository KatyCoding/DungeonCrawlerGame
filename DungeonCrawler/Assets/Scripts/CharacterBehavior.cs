using UnityEngine;

public class CharacterBehavior : EntityBehavior
{
    public override void Update()
    {
        base.Update();
        if (mainAttackReady)
        {
            if (GameMaster.CurrentRoom != null)
                MainAttack(GameMaster.CurrentRoom.enemies[0]);
        }
    }
}