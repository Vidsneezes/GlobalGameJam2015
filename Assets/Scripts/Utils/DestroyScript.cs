using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour
{

		public float destroyTime;
		
		// Use this for initialization
		void Start ()
		{
				Destroy (gameObject, destroyTime);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
