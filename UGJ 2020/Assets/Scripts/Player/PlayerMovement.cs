using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed;

   private Vector3 inputVector;
   private Vector3 moveVector;
   private float _horizontalInput;
   private float _verticalInput;
   [SerializeField] private string _horizontalInputString;
   [SerializeField] private string _verticalInputString;
   [SerializeField] private CharacterController _charController;
   [SerializeField] private Animator _animator; // loaded in Inspector

   // Start is called before the first frame update
   void Start()
   {
      _charController = GetComponent<CharacterController>();
   }

   // Update is called once per frame
   void Update()
   {
      _verticalInput = Input.GetAxisRaw(_verticalInputString);
      _horizontalInput = Input.GetAxisRaw(_horizontalInputString);
      inputVector = new Vector3(_horizontalInput, 0f, _verticalInput);

      Movement();
      UpdateAnimations();
   }

   private void Movement()
   {
      moveVector = (this.transform.forward * _verticalInput) + (this.transform.right * _horizontalInput);

      if (moveVector.magnitude > 1.0f)
      {
         moveVector.Normalize();
      }

      moveVector = moveVector * moveSpeed;
      _charController.Move(moveVector * Time.deltaTime);
   }

   private void UpdateAnimations()
   {
      //Debug.Log("Input Magnitude = " + inputVector.magnitude);
      _animator.SetFloat("LeftStickVert_Input", inputVector.magnitude);
   }
}
