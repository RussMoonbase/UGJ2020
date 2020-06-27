using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;
   public GameObject player1;
   public GameObject player2;
   public Vector3 player1RespawnPosition;
   public Vector3 player2RespawnPosition;

   public bool TestBool = false;


   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
   }

   // Start is called before the first frame update
   void Start()
   {
      player1RespawnPosition = player1.transform.position;
      player2RespawnPosition = player2.transform.position;
   }

   // Update is called once per frame
   void Update()
   {
      if (TestBool)
      {
         Respawn();
      }
   }

   public void Respawn()
   {
      StartCoroutine(RespawnCoroutine());
   }

   private IEnumerator RespawnCoroutine()
   {
      player1.SetActive(false);
      player2.SetActive(false);

      yield return new WaitForSeconds(2f);

      player1.SetActive(true);
      player2.SetActive(true);
      player1.GetComponent<PlayerDamage>().DeactivateRagdoll();
      player2.GetComponent<PlayerDamage>().DeactivateRagdoll();
      player1.transform.position = player1RespawnPosition;
      player2.transform.position = player2RespawnPosition;

   }
}
