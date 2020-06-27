using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePunch : MonoBehaviour
{
   public Punch punch; // loaded in Inspector

   public void SetPunchToTrue()
   {
      if (punch)
      {
         punch.isPunchReady = true;
      }
   }

   public void SetPunchToFalse()
   {
      if (punch)
      {
         punch.isPunchReady = false;
      }
   }

}
