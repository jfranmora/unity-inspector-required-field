using System;
using UnityEngine;

namespace JfranMora.Inspector
{
	[AttributeUsage(AttributeTargets.Field)]
	public class RequiredFieldAttribute : PropertyAttribute
	{
	}
}