
using System;
using System.Collections;
using UnityEngine;

namespace Library
{
	public class Scaling : MonoBehaviour
	{
		Vector2 startTouchPosition = Vector3.zero;
		Vector3 currentScale = Vector3.zero;

		void Start()
		{
			currentScale = transform.localScale;
		}

		void Update()
		{
			if(Input.touchCount > 0)
			{
				Touch touch = Input.touches[0];
					
				switch(touch.phase)
				{
					case TouchPhase.Began:
					{
						startTouchPosition = touch.position;
						StopAllCoroutines();
						break;
					}
					case TouchPhase.Ended: 
					{
						Vector3 localScale = transform.localScale;
						Vector2 direction = touch.position - startTouchPosition;
						float distance = direction.magnitude;

						direction.Normalize();
						direction.x = Mathf.Abs(direction.x);
						direction.y = Mathf.Abs(direction.y);

						currentScale = ClampScale(direction,distance,localScale);

						break;
					}
				}
			}

			transform.localScale = Vector3.Lerp(transform.localScale,currentScale,Time.deltaTime * 30f);
		}

		Vector3 ClampScale(Vector3 direction,float distance,Vector3 localScale)
		{
			int slideFactor = 4;
			float min = 0.5f;
			float max = 2.0f;
			float normal = 1.0f;

			if(direction.x > direction.y)
			{
				if(distance >= Screen.width/slideFactor)
				{
					if(localScale.y > normal)
					{
						localScale.x = normal;
						localScale.y = normal;
					}
					else if(localScale.x > normal)
					{
						localScale.x = normal;
						localScale.y = normal;
					}
					else
					{
						localScale.x = max;
						localScale.y = min;
					}
				}
			}
			else
			{
				if(distance >= Screen.height/slideFactor)
				{
					if(localScale.x > normal)
					{
						localScale.x = normal;
						localScale.y = normal;
					}
					else if(localScale.y > normal)
					{
						localScale.x = normal;
						localScale.y = normal;
					}
					else
					{
						localScale.x = min;
						localScale.y = max;
					}
				}
			}

			localScale.x *= GetComponent<PlayerMovement>().GetMoveDirection();
			return localScale;
		}


	}
}

