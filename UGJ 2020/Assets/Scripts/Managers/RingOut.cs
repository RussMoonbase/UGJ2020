﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOut : MonoBehaviour
{
   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {

   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player1")
      {
         PlayerDamage pDamage = other.GetComponent<PlayerDamage>();

         if (pDamage)
         {
            bool playerOutOfRing = pDamage.playerWalkedOutRing;

            if (!playerOutOfRing)
            {
               pDamage.ActivateRagdoll(false);
            }
         }
         
         //Debug.Log("Player1 RING OUT!");
         GameManager.instance.player2Score += 1;
         UIManager.instance.UpdatePlayer2Score(GameManager.instance.player2Score);
      }

      if (other.tag == "Player2")
      {
         PlayerDamage pDamage = other.GetComponent<PlayerDamage>();

         if (pDamage)
         {
            bool playerOutOfRing = pDamage.playerWalkedOutRing;

            if (!playerOutOfRing)
            {
               pDamage.ActivateRagdoll(false);
            }
         }

         //Debug.Log("Player2 RING OUT!");
         GameManager.instance.player1Score += 1;
         UIManager.instance.UpdatePlayer1Score(GameManager.instance.player1Score);
      }
   }
}
