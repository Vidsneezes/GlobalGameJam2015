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
		
		public void Activated ()
		{
				if (messageDisplayed == false) {
						messageDisplayed = true;
						GameObject prompter = GameObject.Find ("MessagePrompter");
						MessageInformer temp = prompter.GetComponent<MessageInformer> ();
						if (informationElements != null && informationElements.Count > 0) {
								temp.DisplayMessage (informationElements [0].message);
								Invoke ("canViewMessageAgain", informationElements [0].fireRate);
						}
				}
		}
		
		void canViewMessageAgain ()
		{
				messageDisplayed = false;
		}
}
