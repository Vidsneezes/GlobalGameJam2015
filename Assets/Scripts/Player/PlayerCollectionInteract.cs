using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using InControl;


public class PlayerCollectionInteract : MonoBehaviour
{

		private float
				sanity;
	
		private GameObject targetDistance;
	
		private GameObject cameraPosition;
	
		public int interactionDistance;
	
		public float interactionWait;
		public bool justInteracted;
		
		private GameObject alarmClock;
		
		
		
	
		// Use this for initialization
		void Start ()
		{
		
				targetDistance = GameObject.Find ("TargetDistance");
				cameraPosition = GameObject.Find ("Main Camera");
				
				
		
		}
	
		void EnableInteraction ()
		{
				justInteracted = false;
		}
	
		// Update is called once per frame
		void Update ()
		{
				var inputeDevice = InputManager.ActiveDevice;
		
				if ((inputeDevice.Action1 || inputeDevice.RightTrigger) && targetDistance != null) {
						Debug.DrawLine (cameraPosition.transform.position, targetDistance.transform.position, Color.blue, interactionDistance);
						RaycastHit info = new RaycastHit ();
						if (Physics.Linecast (cameraPosition.transform.position, targetDistance.transform.position, out info, interactionDistance) && justInteracted == false) {
								InteractionInformation temp = info.collider.gameObject.GetComponent<InteractionInformation> ();
								if (temp != null) {
										if (info.collider.gameObject.name == alarmClock.name) {
												alarmClock.audio.Stop ();
										}
								}
						}
			
			
				}
		}
		
}
