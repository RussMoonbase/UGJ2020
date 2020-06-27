using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed;

   private Vector3 moveVector;
   [SerializeField] private string _horizontalInput;
   [SerializeField] private string _verticalInput;
   [SerializeField] private CharacterController _charController;

   // Start is called before the first frame update
   void Start()
   {
      _charController = GetComponent<CharacterController>();
   }

   // Update is called once per frame
   void Update()
   {
      Movement();
   }

   private void Movement()
   {
      moveVector = (this.transform.forward * Input.GetAxisRaw(_verticalInput)) + (this.transform.right * Input.GetAxisRaw(_horizontalInput));
      moveVector.Normalize();
      moveVector = moveVector * moveSpeed;

      _charController.Move(moveVector * Time.deltaTime);
   }
}
