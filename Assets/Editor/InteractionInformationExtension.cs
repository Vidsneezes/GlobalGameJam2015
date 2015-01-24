using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;


[CustomEditor(typeof(InteractionInformation))]
public class InteractionInformationExtension :  Editor
{

		bool informationElementFoldeout;

		Vector2 scrollPosition;

		public override void OnInspectorGUI ()
		{
		
				InteractionInformation inform = (InteractionInformation)target;
				DrawDefaultInspector ();
				informationElementFoldeout = EditorGUILayout.Foldout (informationElementFoldeout, "Information Elements");
				
				
				if (informationElementFoldeout) {
						if (inform.informationElements != null) {
								for (int i = 0; i < inform.informationElements.Count; i++) {
										inform.informationElements [i].foldout = EditorGUILayout.Foldout (inform.informationElements [i].foldout, "Content " + i);
										if (inform.informationElements [i].foldout) {
												inform.informationElements [i].message = EditorGUILayout.TextField ("Message", inform.informationElements [i].message);
												inform.informationElements [i].sanityLower = EditorGUILayout.FloatField ("When Sanity is Lower Than", inform.informationElements [i].sanityLower);
												inform.informationElements [i].fireRate = EditorGUILayout.FloatField ("FireRate", inform.informationElements [i].fireRate);
						
												
												
												if (inform.informationElements [i].instances != null) {
														for (int j = 0; j < inform.informationElements[i].instances.Count; j++) {
																inform.informationElements [i].instances [j] = (GameObject)EditorGUILayout.ObjectField ("Prefab " + j, inform.informationElements [i].instances [j], typeof(GameObject), false);
														}
												}
												
												if (GUILayout.Button ("Add Instances Interaction")) {
														if (inform.informationElements [i].instances == null) {
																inform.informationElements [i].instances = new List<GameObject> ();
								
														}
														inform.informationElements [i].instances.Add (null);
												}
												
												if (GUILayout.Button ("Remove Instances Interaction") && inform.informationElements [i].instances.Count > 0) {
														inform.informationElements [i].instances.RemoveAt (inform.informationElements [i].instances.Count - 1);
												}
												
												inform.informationElements [i].material = (Material)EditorGUILayout.ObjectField ("Material", inform.informationElements [i].material, typeof(Material), false);
												
										}
								}
						}
						
				}
				
				if (GUILayout.Button ("Add Interaction")) {
						if (inform.informationElements == null) {
								inform.informationElements = new List<InformationElement> ();
						}
						inform.informationElements.Add (new InformationElement ());
				}
				
				if (GUILayout.Button ("Clear List")) {
						inform.informationElements.Clear ();
				}
				
		}
}
