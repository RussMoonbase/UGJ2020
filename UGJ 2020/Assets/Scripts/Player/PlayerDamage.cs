using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
   public GameObject player1Cam;
   public GameObject player2Cam;
   [SerializeField] private GameObject _opponentCam;

   public static PlayerDamage instance;

   public bool testbool = false;
   public Rigidbody headRB;

   private Rigidbody[] _rigidbodies;
   [SerializeField] private Collider[] _colliders;

   // loaded in Inspector
   [SerializeField] private Animator _animator;
   [SerializeField] private CharacterController _charController;
   [SerializeField] private PlayerMovement _playerMovement;

   public bool playerWalkedOutRing = false;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      player1Cam = GameObject.Find("/Player1 Cam");
      player1Cam = GameObject.Find("/Player2 Cam");


      if (this.gameObject.tag == "Player 1")
      {
         _opponentCam = player2Cam;
      }

      if (this.gameObject.tag == "Player2")
      {
         _opponentCam = player1Cam;
      }

      _rigidbodies = GetComponentsInChildren<Rigidbody>();
      playerWalkedOutRing = false; 
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void ActivateRagdoll(bool forceNeeded)
   {
      playerWalkedOutRing = true;

      if (_playerMovement)
      {
         _playerMovement.enabled = false;
      }

      if (_animator)
      {
         _animator.enabled = false;
      }

      if (_charController)
      {
         _charController.enabled = false;
      }

      foreach (Rigidbody rb in _rigidbodies)
      {
         rb.isKinematic = false;

         if (forceNeeded)
         {
            if (_opponentCam)
            {
               rb.AddForce(-_opponentCam.transform.forward * 45, ForceMode.Impulse);
            }
            else
            {
               rb.AddForce(-this.transform.forward * 45, ForceMode.Impulse);
            }
            
         }     
      }

      foreach (Collider col in _colliders)
      {
         col.enabled = true;
      }
   }

   public void DeactivateRagdoll()
   {
      foreach (Rigidbody rb in _rigidbodies)
      {
         rb.isKinematic = true;
         //rb.AddForce(-this.transform.forward * 45, ForceMode.Impulse);
      }

      foreach (Collider col in _colliders)
      {

         if (col.gameObject.name != "mixamorig:RightHand")
         {
            col.enabled = false;
         }

      }

      if (_playerMovement)
      {
         _playerMovement.enabled = true;
      }

      if (_animator)
      {
         _animator.enabled = true;
      }

      if (_charController)
      {
         _charController.enabled = true;
      }
   }
}
