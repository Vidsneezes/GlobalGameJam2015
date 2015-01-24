using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(InteractionInformation))]
public class InteractionInformationExtension :  Editor
{

		public override void OnInspectorGUI ()
		{
		
				InteractionInformation inform = (InteractionInformation)target;
				DrawDefaultInspector ();
		}
}
