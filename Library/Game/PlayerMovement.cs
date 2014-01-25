using System;
using UnityEngine;

namespace Library
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] Vector3 direction = Vector3.zero;
		[SerializeField] float speed = 10f;

		void Start()
		{

		}

		void FixedUpdate()
		{
			rigidbody2D.velocity = direction * speed;
		}
	}
}

