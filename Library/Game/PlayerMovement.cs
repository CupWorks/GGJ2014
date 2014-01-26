using System;
using UnityEngine;

namespace Library
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] float speed = 10f;

		enum MoveDirection { Left, Right }
		MoveDirection moveDirection;
		Vector2 direction = Vector2.zero;

		const float GRAVITY = 15f;
		Vector2 gravitation = new Vector2(0,-1f);

		void Start()
		{
			Vector3 scale = transform.localScale;
			if(scale.x >= 0)
			{
				moveDirection = MoveDirection.Right;
				direction = Vector2.right;
			}
			else
			{
				moveDirection = MoveDirection.Left;
				direction = -Vector2.right;
			}
		}

		void FixedUpdate() 
		{
			Vector2 velocity = Vector2.zero;
			Vector2 forward = transform.TransformDirection(direction.normalized);
			Vector2 down = (Vector2)transform.TransformDirection(-Vector2.up);
			Vector2 localScale = new Vector2(transform.localScale.x,transform.localScale.y);

			gravitation = (Vector2)Input.acceleration.normalized;

			transform.rotation = RotateTo(gravitation.x,gravitation.y);

			if(CanMove(forward) || IsGrounded(localScale.x,down) || IsGrounded(-localScale.x,down) || IsGrounded(0,down))
			{
				velocity += forward * speed;
			}
			velocity += down * GRAVITY;

			rigidbody2D.velocity = velocity;
		}

		bool CanMove(Vector2 forward)
		{
			int layer = ~(1 << 8); //All Layers to 8 (Ignore Movement)
			float distance = transform.localScale.magnitude;

			return !Physics2D.Raycast(transform.position,forward,distance,layer);
		}

		bool IsGrounded(float offsetX,Vector2 down)
		{
			int layer = ~(1 << 8); //All Layers to 8 (Ignore Movement)
			float distance = transform.localScale.magnitude;
			Vector2 position = (Vector2)transform.position;
			position.x += offsetX;
			Debug.DrawRay(position,down*distance);
			return Physics2D.Raycast(position,down,distance,layer);
		}

		Quaternion RotateTo(float horizontal, float vertical)
		{
			if(Mathf.Abs(horizontal) > Mathf.Abs(vertical))
			{

				vertical = 0;
			}
			else
			{
				horizontal = 0;
			}

			float angle = Mathf.Atan2(-horizontal, vertical) * Mathf.Rad2Deg;
			switch(moveDirection)
			{
			case MoveDirection.Left:
				return Quaternion.Euler(new Vector3(0, 0, angle - 180));
			case MoveDirection.Right:
				return Quaternion.Euler(new Vector3(0, 0,angle + 180));
			default :
				return Quaternion.identity;
			}
		}

		public int GetMoveDirection()
		{
			switch(moveDirection)
			{
			case MoveDirection.Left:
				return -1;
			case MoveDirection.Right:
				return 1;
			default:
				return 0;
			}
		}
	}
}

