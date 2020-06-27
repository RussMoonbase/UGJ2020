using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   public string punchButtonString;
   public float hitLevelIncreaseSpeed;

   [SerializeField] private Animator _animator; // loaded in Inspector
   [SerializeField] private float _hitLevelMax;
   private float _hitLevel = 0f;
   private bool _isPunchButtonPressed = false;

   // Start is called before the first frame update
   void Start()
   {

   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetButton(punchButtonString))
      {
         _isPunchButtonPressed = true;
      }

      if (Input.GetButtonUp(punchButtonString))
      {
         if (_hitLevel >= _hitLevelMax)
         {
            Attack();
         }
         _isPunchButtonPressed = false;
      }

      PressingPunchButton();
   }

   private void PressingPunchButton()
   {
      if (_isPunchButtonPressed)
      {
         _hitLevel += hitLevelIncreaseSpeed;
         _animator.SetFloat("HitLevel", _hitLevel);
      }
      else
      {
         if (_hitLevel > 0.1f)
         {
            _hitLevel -= (hitLevelIncreaseSpeed / 2);
            _animator.SetFloat("HitLevel", _hitLevel);
         }
      }
   }

   private void Attack()
   {
      _hitLevel = 0f;
      _animator.SetFloat("HitLevel", _hitLevel);
      _animator.SetTrigger("Punch");
   }
}
