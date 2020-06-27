using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
   public bool testbool = false;

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
      }

      foreach (Collider col in _colliders)
      {
         col.enabled = true;
      }
   }

}
