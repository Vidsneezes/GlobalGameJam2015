using UnityEngine;
using System.Collections;

public class MessageInformer : MonoBehaviour
{
		[HideInInspector]
		public string
				message;
		[HideInInspector]
		public TextMesh
				textMesh;

		// Use this for initialization
		void Start ()
		{
				textMesh = GetComponent<TextMesh> ();
		}
	
		public void DisplayMessage (string message)
		{
				textMesh.color = new Color (1, 1, 1, 1);
				textMesh.text = message;
				Invoke ("CloseMessage", 1.2f);
		}
		
		void CloseMessage ()
		{
				textMesh.color = new Color (1, 1, 1, 0);
		}
}
