using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(InteractionInformation))]
public class InteractionInformationExtension :  Editor
{

		public override void OnInspectorGUI ()
		{
		
				InteractionInformation inform = (InteractionInformation)target;
				DrawDefaultInspector ();
				
				if (inform.informationElements != null) {
						for (int i = 0; i < inform.informationElements.Count; i++) {
								inform.informationElements [i].message = EditorGUILayout.TextField ("Message", inform.informationElements [i].message);
								inform.informationElements [i].sanityLower = EditorGUILayout.FloatField ("When Sanity is Lower Than", inform.informationElements [i].sanityLower);
								inform.informationElements [i].fireRate = EditorGUILayout.FloatField ("FireRate", inform.informationElements [i].fireRate);
						}
				}
				
				if (GUILayout.Button ("Add Interaction")) {
						if (inform.informationElements == null) {
								inform.informationElements = new List<InformationElement> ();
						}
						inform.informationElements.Add (new InformationElement ());
				}
		}
}
