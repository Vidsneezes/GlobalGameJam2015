using UnityEngine;
using System.Collections;
using InControl;

public class PlayerInteraction : MonoBehaviour
{

		[Range(0,100)]
		public float
				sanity;
				
		private GameObject targetDistance;
		
		public int interactionDistance;

		// Use this for initialization
		void Start ()
		{
		
				targetDistance = GameObject.Find ("TargetDistance");
			
		}
	
		// Update is called once per frame
		void Update ()
		{
				var inputeDevice = InputManager.ActiveDevice;
				
				if (inputeDevice.Action1 && targetDistance != null) {
						Debug.DrawLine (transform.position, targetDistance.transform.position);
						RaycastHit info = new RaycastHit ();
						if (Physics.Raycast (transform.position, targetDistance.transform.position, out info, interactionDistance)) {
								ChangeColor temp = info.collider.gameObject.GetComponent<ChangeColor> ();
								if (temp != null) {
										temp.Activated ();
								}
						}
						
						
				}
				
		}
}
