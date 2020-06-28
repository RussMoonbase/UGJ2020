using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public int player1Score = 0;
   public int player2Score = 0;

   public GameObject player1Prefab;
   public GameObject player2Prefab;

   public static GameManager instance;
   public GameObject player1;
   public GameObject player2;
   public Vector3 player1RespawnPosition;
   public Vector3 player2RespawnPosition;
   public Quaternion player1RespawnRotation;
   public Quaternion player2RespawnRotation;

   public CameraLogic player1CameraLogic;
   public CameraLogic player2CameraLogic;

   public bool player1Respawned = false;
   public bool player2Respawned = false;

   private GameObject _player1SpawnedObj;
   private GameObject _player2SpawnedObj;

   private GameObject[] _players;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      player1RespawnPosition = player1.transform.position;
      player1RespawnRotation = player1.transform.rotation;
      player2RespawnPosition = player2.transform.position;
      player2RespawnRotation = player2.transform.rotation;
   }

   // Update is called once per frame
   void Update()
   {
      CheckForWinner();
   }

   public void Respawn()
   {
      StartCoroutine(RespawnCoroutine());
   }

   private IEnumerator RespawnCoroutine()
   {
      UIManager.instance.fadeToColor = true;
      player1CameraLogic.cineBrain.enabled = false;
      player2CameraLogic.cineBrain.enabled = false;

      player1 = GameObject.FindGameObjectWithTag("Player1");
      player2 = GameObject.FindGameObjectWithTag("Player2");

      Destroy(player1);
      Destroy(player2);

      yield return new WaitForSeconds(2f);

      if (!player1Respawned)
      {
         _player1SpawnedObj = Instantiate(player1Prefab, player1RespawnPosition, player1RespawnRotation);
         player1Respawned = true;
      }

      if (!player2Respawned)
      {
         _player2SpawnedObj = Instantiate(player2Prefab, player2RespawnPosition, player2RespawnRotation);
         player2Respawned = true;
      }

      player1CameraLogic.UpdateVirtualCamFollow(_player1SpawnedObj.GetComponent<PlayerCamTarget>().GetCamTarget());
      player1CameraLogic.cineBrain.enabled = true;
      player2CameraLogic.UpdateVirtualCamFollow(_player2SpawnedObj.GetComponent<PlayerCamTarget>().GetCamTarget());
      player2CameraLogic.cineBrain.enabled = true;
      UIManager.instance.fadeToClear = true;

      StartCoroutine(ReturnRespawnToFalseCo());
   }

   private IEnumerator ReturnRespawnToFalseCo()
   {
      yield return new WaitForSeconds(4f);
      player1Respawned = false;
      player2Respawned = false;
   }

   private void CheckForWinner()
   {
      if (player1Score >= 3)
      {
         StartCoroutine(LoadWinningScene(2));
      }

      if (player2Score >= 3)
      {
         StartCoroutine(LoadWinningScene(3));
      }
   }

   private IEnumerator LoadWinningScene(int index)
   {
      MusicManager.instance.gameFinished = true;
      yield return new WaitForSeconds(2.0f);
      SceneLoader.instance.LoadSceneNumber(index);
   }
}
