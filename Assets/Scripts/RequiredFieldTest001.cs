using System.Collections.Generic;
using JfranMora.Inspector;
using UnityEngine;

public class RequiredFieldTest001 : MonoBehaviour
{
	[Header("Objects")]	
	[RequiredField] public GameObject obj;	
	[RequiredField] public Camera cam;	
	[RequiredField] public Transform t;

	// Ignoring not object values
	[Header("Not objects")]		
	[RequiredField] public int intVal;
	[RequiredField] public float floatVal;
	[RequiredField] public Vector3 vector3;

	// TODO: Not working with elements inside a list / array
	[Header("Lists")]		
	[RequiredField] public List<GameObject> list;	
	[RequiredField] public GameObject[] array;

	// TODO: Not working with nested elements
	[Header("Structs")]
	public Container cnt;

	[System.Serializable]
	public struct Container
	{
		[RequiredField] public GameObject g;
		[RequiredField] public Transform t;
	}
}
