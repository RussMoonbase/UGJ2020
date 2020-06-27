using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
   public bool isPunchReady = false;
   public string enemyPlayerTag;

   [SerializeField] private PlayerDamage _playerDamage; // loaded in Inspector

   // Start is called before the first frame update
   void Start()
   {

   }


   // Update is called once per frame
   void Update()
   {

   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag == enemyPlayerTag && isPunchReady)
      {
         Debug.Log("TRUE");

         if (other.GetComponent<PlayerDamage>())
         {
            other.GetComponent<PlayerDamage>().ActivateRagdoll();
         }
      }
      
   }
}
