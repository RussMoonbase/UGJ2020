using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamTarget : MonoBehaviour
{
   [SerializeField] private Transform _camTarget; // loaded in Inspector

   public Transform GetCamTarget()
   {
      return _camTarget;
   }
}
