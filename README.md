# [Unity] Inspector Extensions - Required Field
Custom attribute to cancel play mode if a property with `[RequiredField]` attribute is null. (In current scene) 

## Installation (Manual)
Download the release https://github.com/jfranmora/unity-inspector-required-field/archive/0.1.0.zip and unzip it in the project.

## Installation (UPM)
Add to `manifest.json` as dependency the following line:

`"com.jfranmora.inspector.required-field": "https://github.com/jfranmora/unity-inspector-required-field.git#upm"`

## How to use
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

## TODO
- [X] Simple fields
- [ ] Add compatibility with Array/Lists
- [ ] Add compatibility with Nested struct/object
