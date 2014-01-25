using System;
using UnityEngine;

namespace Library
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] Vector3 direction = Vector3.zero;
		[SerializeField] float speed = 10f;

		static Vector3 gravity = Vector3.down;
		const float GRAVITY = 9.81f;

		void FixedUpdate() 
		{
			rigidbody2D.velocity = ((direction * speed) + (gravity * GRAVITY));
			gravity = Input.acceleration;
		}

		public Vector3 GetMoveDirection()
		{
			return direction;
		}



		void OnGUI()
		{
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"Axis " + Input.acceleration);
			if(GUI.Button(new Rect(Screen.width-200,0,Screen.width,Screen.height),"Reset"))
			{
				Application.LoadLevel(Application.loadedLevelName);
			}
		}
	}
}

