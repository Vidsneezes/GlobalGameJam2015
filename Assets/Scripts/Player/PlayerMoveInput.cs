using UnityEngine;
using System.Collections;
using InControl;

public class PlayerMoveInput : MonoBehaviour
{

		public int speed = 10;
		private Vector3 direciton;
		
		private CharacterController characterController;

		// Use this for initialization
		void Start ()
		{
				characterController = GetComponent<CharacterController> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
				var inputDevice = InputManager.ActiveDevice;
				//Normalize movement
				
				Vector3 directionVector = new Vector3 (inputDevice.Direction.X, 0, inputDevice.Direction.Y);
				if (directionVector != Vector3.zero) {
						var directionLength = directionVector.magnitude;
						directionVector = directionVector / directionLength;
			
						directionLength = Mathf.Min (1, directionLength);
			
						directionLength = directionLength * directionLength;
			
						directionVector = directionVector * directionLength;
				}
		
				direciton = transform.rotation * directionVector;
		
				Vector3 alterDirection = new Vector3 (direciton.x, 0, direciton.z);
		
				var desiredLocalDirection = transform.InverseTransformDirection (direciton);
				transform.TransformDirection (desiredLocalDirection);
		
		
				characterController.Move (alterDirection * speed * Time.deltaTime);
				
		}
}
