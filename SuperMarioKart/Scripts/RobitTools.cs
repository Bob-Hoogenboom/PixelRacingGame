using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public static class RobitTools
	{
		public static void ClampAngle(ref Vector3 angle)
		{
			if(angle.x < 0) angle.x += 360;
			else if(angle.x > 360) angle.x -= 360;
			
			if(angle.y < 0) angle.y += 360;
			else if(angle.y > 360) angle.y -= 360;
			
			if(angle.z < 0) angle.z += 360;
			else if(angle.z > 360) angle.z -= 360;
		}
	}
