using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour , IInteractable
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		
		public void Activated ()
		{
				renderer.material.color = Color.blue;
		}
}
