using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class InformationElement
{

		public string message;
		public float fireRate;
		public float sanityLower;
		public bool foldout;
		public List<GameObject> instances;
		public Material material;
		public AudioClip effect;
		
		public InformationElement ()
		{
				message = "";
				fireRate = 0;
				sanityLower = 0;
				foldout = false;
		}
}

[RequireComponent(typeof(AudioSource))]
public class InteractionInformation : MonoBehaviour , IInteractable
{

		[HideInInspector]
		public List<InformationElement>
				informationElements;
		private bool messageDisplayed;
		
		private PlayerInteraction playerInteraction;
		
		
		
		
		void Start ()
		{
				playerInteraction = GameObject.Find ("MainPlayer").GetComponent<PlayerInteraction> ();
			
		}
		
		public void Activated ()
		{
				if (messageDisplayed == false) {
						messageDisplayed = true;
						GameObject prompter = GameObject.Find ("MessagePrompter");
						MessageInformer temp = prompter.GetComponent<MessageInformer> ();
						
						Debug.Log ("Test");
			
						for (int i = 0; i < informationElements.Count; i++) {
								if (informationElements [i].sanityLower <= playerInteraction.sanity) {
										temp.DisplayMessage (informationElements [i].message);
										for (int j = 0; j < informationElements[i].instances.Count; j++) {
												Instantiate (informationElements [i].instances [j], transform.position, Quaternion.identity);
										}
										if (informationElements [i].material != null) {
												renderer.material = informationElements [i].material;
										}
										if (informationElements [i].effect != null) {
												audio.PlayOneShot (informationElements [i].effect, 1f);
										}
										Invoke ("canViewMessageAgain", informationElements [i].fireRate);
										
										break;
								}
						}
				}
		}
		
		void canViewMessageAgain ()
		{
				messageDisplayed = false;
		}
}
