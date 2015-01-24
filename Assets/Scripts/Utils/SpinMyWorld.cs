using UnityEngine;
using System.Collections;

public class SpinMyWorld : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				float temp = transform.eulerAngles.y + 10 * Time.deltaTime;
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, temp, transform.eulerAngles.z);
		}
}
