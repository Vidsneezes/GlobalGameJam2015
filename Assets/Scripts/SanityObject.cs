using UnityEngine;
using System.Collections;

public class SanityObject : MonoBehaviour
{

		private PlayerInteraction playerInteraction;

		// Use this for initialization
		void Start ()
		{
				playerInteraction = GameObject.Find ("MainPlayer").GetComponent<PlayerInteraction> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
