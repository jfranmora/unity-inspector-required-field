using System;
using UnityEngine;

namespace JfranMora.RequiredField
{
	[AttributeUsage(AttributeTargets.Field)]
	public class RequiredFieldAttribute : PropertyAttribute
	{
	}
}