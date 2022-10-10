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

		private Transform _transform;

		public Vector2 currentRotation { get { return _angle; } }

		void Start()
		{
			_transform = transform;
			_oldRotation = _transform.rotation;
			_angle.y = angleY;
			target = GameObject.FindWithTag("Player").transform;
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

				_transform.position = target.position - currentRotation * Vector3.forward * distance;
				_transform.LookAt(target.position, Vector3.up);
			}
		}
	}
