using UnityEngine;
using System.Collections;


	public class CameraDirection : MonoBehaviour
	{
		protected CameraController _camera;
		
		public virtual Vector2 Angle { get { return _camera.currentRotation; } }

		public virtual void Awake()
		{
			_camera = GetComponent<CameraController>();
		}
		
	}
