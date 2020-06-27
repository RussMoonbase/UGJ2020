using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
   public bool testbool = false;
   public Rigidbody headRB;

   private Rigidbody[] _rigidbodies;
   [SerializeField] private Collider[] _colliders;

   // loaded in Inspector
   [SerializeField] private Animator _animator;
   [SerializeField] private CharacterController _charController;
   [SerializeField] private PlayerMovement _playerMovement;

   // Start is called before the first frame update
   void Start()
   {
      _rigidbodies = GetComponentsInChildren<Rigidbody>();
   }

   // Update is called once per frame
   void Update()
   {
      if (testbool)
      {
         ActivateRagdoll();
      }
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

      if (headRB)
      {
         //headRB.AddForce(this.transform.up * 15, ForceMode.Impulse);
         headRB.AddForce(-this.transform.forward * 55, ForceMode.Impulse);
      }
   }

   public void DeactivateRagdoll()
   {
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

      foreach (Rigidbody rb in _rigidbodies)
      {
         rb.isKinematic = true;
         //rb.AddForce(-this.transform.forward * 45, ForceMode.Impulse);
      }

      foreach (Collider col in _colliders)
      {
         col.enabled = false;
      }
   }
}
