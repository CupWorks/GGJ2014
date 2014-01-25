using System;
using UnityEngine;

namespace Library
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] Vector3 direction = Vector3.zero;
		[SerializeField] Vector3 gravity = Vector3.down;
		[SerializeField] float speed = 10f;

		const float GRAVITY = 9.81f;

		void FixedUpdate() 
		{
			rigidbody2D.velocity = ((direction * speed) + (gravity * GRAVITY));
		}

		public Vector3 GetMoveDirection()
		{
			return direction;
		}
	}
}

