using UnityEngine;
using System.Collections;

public class InformationElement
{

		public string message;
		public float fireRate;
		
		public InformationElement ()
		{
	
		}
}


public class InteractionInformation : MonoBehaviour , IInteractable
{

		public InformationElement informationElement;
		private bool messageDisplayed;
		
		public void Activated ()
		{
				if (messageDisplayed == false) {
						messageDisplayed = true;
						GameObject prompter = GameObject.Find ("MessagePrompter");
						MessageInformer temp = prompter.GetComponent<MessageInformer> ();
						temp.DisplayMessage (informationElement.message);
						Invoke ("canViewMessageAgain", informationElement.fireRate);
				}
		}
		
		void canViewMessageAgain ()
		{
				messageDisplayed = false;
		}
}
