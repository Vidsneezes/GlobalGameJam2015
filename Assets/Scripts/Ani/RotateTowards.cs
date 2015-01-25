using UnityEngine;
using System.Collections;

public class RotateTowards : MonoBehaviour
{

		public float moveToPosition;
		RectTransform rectTransform;
	
		// Use this for initialization
		void Start ()
		{
				rectTransform = GetComponent<RectTransform> ();
				Debug.Log (rectTransform.rotation);
		}
	
		// Update is called once per frame
		void Update ()
		{
				rectTransform.eulerAngles = Vector3.MoveTowards (rectTransform.eulerAngles, Vector3.zero, moveToPosition);
		}
}
