using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

public class InstanceElement
{
		public Vector3 startPosition;
		
		public bool remove;
		
		public Rect size;
	
		public InstanceElement (Vector2 start)
		{
		
				startPosition = new Vector3 (start.x, start.y, 0);
				size = new Rect (startPosition.x, startPosition.y, 5, 5);
				
				remove = false;
		
		}
	
		
	
		public void Update (Event e)
		{
				if (e.button == 1 && e.rawType == EventType.mouseDown && size.Contains (e.mousePosition)) {
			
						remove = true;
				}
		}
	
		public void Render ()
		{
		
				EditorGUI.DrawRect (size, Color.blue);
		}
}

public class FloorPlanLayoutEditor : EditorWindow
{

		private bool connectionNeeded = false;
		private bool lineConnected = false;
		public Vector2 scrollPosition;
		
		float panX, panY;
		Vector2 startPos, endPos;
		
		
		public List<InstanceElement> lines = new List<InstanceElement> ();
		
		public List<InstanceElement> vertex = new List<InstanceElement> ();
		
		[MenuItem("Window/FloorPlanLayoutEditor")]
		public static void ShowWindow ()
		{
				FloorPlanLayoutEditor editor = (FloorPlanLayoutEditor)EditorWindow.GetWindowWithRect (typeof(FloorPlanLayoutEditor), new Rect (0, 0, 800, 600));
		}
		
		void OnGUI ()
		{
				/*
				if (lineConnected == true) {
				
						lines.Add (new InstanceElement (new Vector2 (startPos.x, startPos.y), new Vector2 (endPos.x, endPos.y)));
						lineConnected = false;
						Repaint ();
					
				}*/
				Event e = Event.current;
				EditorGUI.DrawRect (new Rect (0, 0, Screen.width, 480), new Color (0.2f, 0.2f, 0.2f));
				scrollPosition = GUI.BeginScrollView (new Rect (0, 0, Screen.width, 480), scrollPosition, new Rect (panX, panY, Screen.width, 300));
				
				if (e.button == 0 && e.rawType == EventType.mouseDown && new Rect (0, 0, Screen.width, 480).Contains (e.mousePosition)) {
					
						bool positionTaken = false;
					
						for (int i = 0; i < vertex.Count; i++) {
							
								if (vertex [i].size.Contains (e.mousePosition)) {
										positionTaken = true;
										break;
								}
						}
						if (positionTaken == false) {
								vertex.Add (new InstanceElement (e.mousePosition));
						}
				}
				
				/*	
				if (e.button == 0 && e.rawType == EventType.mouseDown && lineConnected == false && new Rect (0, 0, Screen.width, 480).Contains (e.mousePosition)) {
						if (connectionNeeded == true) {
								lineConnected = true;
								connectionNeeded = false;
								endPos = e.mousePosition;
						}
						if (connectionNeeded == false && lineConnected == false) {
								startPos = e.mousePosition;
								connectionNeeded = true;
						}
						
				}
				
				if (connectionNeeded == true) {
						Handles.DrawLine (startPos, e.mousePosition);
						Repaint ();
				}
				
				for (int i = 0; i < lines.Count; i++) {
						lines [i].Render ();
				}*/
				
				for (int i = 0; i < vertex.Count; i++) {
						vertex [i].Update (e);
						vertex [i].Render ();
				}
				
				vertex.RemoveAll (x => x.remove == true);
				
				Repaint ();
				GUI.EndScrollView ();
				
				GUILayout.BeginArea (new Rect (0, 480, Screen.width, 600 - 480));
				if (GUILayout.Button ("Clear Lines")) {
						lines.Clear ();
						Repaint ();
				}
			
				GUILayout.EndArea ();
				
				Debug.Log (startPos);
				Debug.Log (endPos);
				
		}
}
