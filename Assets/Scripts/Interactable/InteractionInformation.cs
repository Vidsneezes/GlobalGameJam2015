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
		
		public InformationElement ()
		{
				message = "";
				fireRate = 0;
				sanityLower = 0;
				foldout = false;
		}
}

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
						for (int i = 0; i < informationElements.Count; i++) {
								if (informationElements [i].sanityLower <= playerInteraction.sanity) {
										temp.DisplayMessage (informationElements [i].message);
										for (int j = 0; j < informationElements[i].instances.Count; j++) {
												Instantiate (informationElements [i].instances [j], transform.position, Quaternion.identity);
										}
										if (informationElements [i].material != null) {
												renderer.material = informationElements [i].material;
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
