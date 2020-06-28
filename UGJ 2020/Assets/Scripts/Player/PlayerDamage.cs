using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
   public static PlayerDamage instance;

   public bool testbool = false;
   public Rigidbody headRB;

   private Rigidbody[] _rigidbodies;
   [SerializeField] private Collider[] _colliders;

   // loaded in Inspector
   [SerializeField] private Animator _animator;
   [SerializeField] private CharacterController _charController;
   [SerializeField] private PlayerMovement _playerMovement;

   private void Awake()
   {
      instance = this;
   }

   // Start is called before the first frame update
   void Start()
   {
      _rigidbodies = GetComponentsInChildren<Rigidbody>();
   }

   // Update is called once per frame
   void Update()
   {

   }

   public void ActivateRagdoll()
   {
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
         rb.AddForce(-this.transform.forward * 45, ForceMode.Impulse);
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
