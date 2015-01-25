using UnityEngine;
using System.Collections;

public class SpinMyWorld : MonoBehaviour
{
		private PlayerInteraction playerInteraction;
		public float speed;
	
		// Use this for initialization
		void Start ()
		{
				playerInteraction = GameObject.Find ("MainPlayer").GetComponent<PlayerInteraction> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				float temp = transform.eulerAngles.y + speed * (1 - (playerInteraction.sanity / 100)) * Time.deltaTime;
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, temp, transform.eulerAngles.z);
		}
}
