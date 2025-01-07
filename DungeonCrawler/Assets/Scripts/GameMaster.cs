using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameMaster : MonoBehaviour
{
   public static List<CharacterBehavior> PlayerCharacters = new List<CharacterBehavior>();
   public static Room CurrentRoom;
   public static void SetPlayerCharacters(List<CharacterBehavior> characters)
   {
      PlayerCharacters = characters;
   }

   public static void SetPlayerCharacters(CharacterBehavior[] characters)
   {
      SetPlayerCharacters(characters.ToList());
   }
   private void Awake()
   {
      SetPlayerCharacters(FindObjectsByType<CharacterBehavior>(UnityEngine.FindObjectsInactive.Exclude,FindObjectsSortMode.None));
   }
}
