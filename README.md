# [Unity] Inspector Extensions - Required Field

Custom attribute to cancel play mode if a property with `[RequiredField]` attribute is null. (In current scene) 

#### How to use
Add `[RequiredField]` to required fields.

``` C#
using UnityEngine;
using JfranMora.Inspector;

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
}
```
