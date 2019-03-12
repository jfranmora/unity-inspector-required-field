using System.Collections.Generic;
using JfranMora.RequiredField;
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
	
	[Header("Lists")]	
	// TODO: Not working with elements inside a list
	[RequiredField] public List<GameObject> list;
	
	// TODO: Not working with elements inside an array
	[RequiredField] public GameObject[] array;
}
