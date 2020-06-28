using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject player2Prefab;

   public static GameManager instance;
   public GameObject player1;
   public GameObject player2;
   public Vector3 player1RespawnPosition;
   public Vector3 player2RespawnPosition;
   public Quaternion player2RespawnRotation;

   public CameraLogic player1CameraLogic;
   public CameraLogic player2CameraLogic;

   public bool player1Respawned = false;
   public bool player2Respawned = false;

   private GameObject _player1SpawnedObj;
   private GameObject _player2SpawnedObj;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      player1RespawnPosition = player1.transform.position;
      player2RespawnPosition = player2.transform.position;
      player2RespawnRotation = player2.transform.rotation;
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void Respawn()
   {
      StartCoroutine(RespawnCoroutine());
   }

   private IEnumerator RespawnCoroutine()
   {
      UIManager.instance.fadeToColor = true;
      player2CameraLogic.cineBrain.enabled = false;

      yield return new WaitForSeconds(2f);

      if (!player2Respawned)
      {
         _player2SpawnedObj = Instantiate(player2Prefab, player2RespawnPosition, player2RespawnRotation);
         player2Respawned = true;
      }
      
      player2CameraLogic.UpdateVirtualCamFollow(_player2SpawnedObj.GetComponent<PlayerCamTarget>().GetCamTarget());
      player2CameraLogic.cineBrain.enabled = true;


      player1.transform.position = player1RespawnPosition;
      UIManager.instance.fadeToClear = true;

   }
}
