using UnityEngine;
using System.Collections;
using UnityEditor.Build.Reporting;


	public class CameraController : MonoBehaviour
	{

		public Transform target;
		public float angleY = 20;
		public float rotationSmoothing = 10;
		public float rotationSensitivity = 10;
		public float distance = 15;

		private Vector3 _angle = new Vector3();
		private Quaternion _oldRotation = new Quaternion();

		private Transform _t;

		public Vector2 CurrentRotation { get { return _angle; } }

		void Start()
		{
			_t = transform;
			_oldRotation = _t.rotation;
			_angle.y = angleY;
		}

		void Update()
		{
			if(target && Input.GetMouseButton(1))
			{
				_angle.x += Input.GetAxis("Mouse X") * rotationSensitivity;
				RobitTools.ClampAngle(ref _angle);
			}
		}

		void LateUpdate()
		{
			if(target)
			{
				Quaternion angleRotation = Quaternion.Euler(_angle.y, _angle.x, 0);
				Quaternion currentRotation = Quaternion.Lerp(_oldRotation, angleRotation, Time.deltaTime * rotationSmoothing);

				_oldRotation = currentRotation;

				_t.position = target.position - currentRotation * Vector3.forward * distance;
				_t.LookAt(target.position, Vector3.up);
			}
		}
	}
