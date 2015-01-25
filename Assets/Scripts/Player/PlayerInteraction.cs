using UnityEngine;
using System.Collections;
using InControl;

public class PlayerInteraction : MonoBehaviour
{

		[Range(0,100)]
		public float
				sanity;
				
		private GameObject targetDistance;
		private GameObject alarmClock;
		private GameObject f_pill;
		private GameObject s_pill;
		private GameObject t_pill;
		private GameObject fo_pill;
		private GameObject fi_pill;
		private GameObject si_pill;
		private GameObject se_pill;
		private GameObject cameraPosition;
		
		public int interactionDistance;
		
		public float interactionWait;
		public bool justInteracted;

		// Use this for initialization
		void Start ()
		{
		
				targetDistance = GameObject.Find ("TargetDistance");
				cameraPosition = GameObject.Find ("Main Camera");
				alarmClock = GameObject.Find ("AlarmClock");
				
				f_pill = GameObject.Find ("FirstPill");
				s_pill = GameObject.Find ("SecondPill");
				t_pill = GameObject.Find ("ThirdPill");
				fo_pill = GameObject.Find ("FourPill");
				fi_pill = GameObject.Find ("FivePill");
				si_pill = GameObject.Find ("SixPill");
				se_pill = GameObject.Find ("SevenPill");
			
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
										temp.Activated ();
										justInteracted = true;
										Invoke ("EnableInteraction", interactionWait);
								}
								
								if (info.collider.gameObject.name.Equals (alarmClock.name)) {
										justInteracted = true;
										Invoke ("EnableInteraction", interactionWait);
										if (alarmClock.audio.isPlaying) {
												alarmClock.audio.Stop ();
												GameObject prompter = GameObject.Find ("MessagePrompter");
												MessageInformer tempInform = prompter.GetComponent<MessageInformer> ();
												tempInform.DisplayMessage ("Turned the alarm off");
										} else {
												GameObject prompter = GameObject.Find ("MessagePrompter");
												MessageInformer tempInform = prompter.GetComponent<MessageInformer> ();
												if (sanity >= 100) {
														tempInform.DisplayMessage ("It's off");
												} else if (sanity >= 75) {
														tempInform.DisplayMessage ("yea it's off");
												} else if (sanity >= 56) {
														tempInform.DisplayMessage ("I know it WAS on..");
												} else if (sanity >= 34) {
														tempInform.DisplayMessage ("aghhh");
												} else if (sanity >= 0) {
														tempInform.DisplayMessage ("It's on");
												}
												
												
										}
								}
						}
						
						
				}
				
		}
}
