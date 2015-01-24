using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InformationElement
{

		public string message;
		public float fireRate;
		public float sanityLower;
		
		public InformationElement ()
		{
				message = "";
				fireRate = 0;
				sanityLower = 0;
		}
}


public class InteractionInformation : MonoBehaviour , IInteractable
{

		public List<InformationElement> informationElements;
		private bool messageDisplayed;
		
		public void Activated ()
		{
				if (messageDisplayed == false) {
						messageDisplayed = true;
						GameObject prompter = GameObject.Find ("MessagePrompter");
						MessageInformer temp = prompter.GetComponent<MessageInformer> ();
					
				}
		}
		
		void canViewMessageAgain ()
		{
				messageDisplayed = false;
		}
}
