//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18052
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Library
{
	public class CameraFollow : MonoBehaviour
	{

		[SerializeField] List<GameObject> targets = new List<GameObject>();
		[SerializeField] float minDistance = 5f;
		[SerializeField] float zOffset = 2;

		float maxDistance = 10f;

		void Start()
		{
			maxDistance = camera.orthographicSize;
		}
		void LateUpdate () 
		{	
			GameObject[] targets = this.targets.ToArray();
		
			Vector3 position = CenterOf(targets);
			Vector3 velocity = VelocityOf(targets);
			Vector3 direction = velocity.normalized;
		
			float distance = DistanceTo(targets,position);
			float speed = velocity.magnitude * Time.deltaTime;

			distance =  Mathf.Lerp(camera.orthographicSize,distance /zOffset,Time.deltaTime);
			camera.orthographicSize = Mathf.Clamp(distance,minDistance,maxDistance);
			position.z = transform.position.z;

			transform.position = Vector3.Lerp(transform.position,position,Time.deltaTime);
		}

		Vector3 CenterOf(GameObject[] targets)
		{
			Vector3 difference = Vector3.zero;
		
			foreach(GameObject target in targets)
			{
				difference += target.transform.position; 
			}
		
			return difference / targets.Length;
		}

		float DistanceTo(GameObject[] targets,Vector3 position)
		{
			float distance = 0;
			foreach(GameObject target in targets)
			{
				distance += Vector3.Distance(position,target.transform.position);
			}
		
			return distance;
		}

		Vector3 VelocityOf(GameObject[] targets)
		{
			Vector2 velocity = Vector2.zero;
		
			int count = 0;
			foreach(GameObject target in targets)
			{
				if(target.rigidbody2D)
				{
					velocity += target.rigidbody2D.velocity;
					count++;
				}
			}
		
			return velocity / count;
		}
	
	public void AddTarget(GameObject target)
	{
		targets.Add(target);
	}
	
	public void RemoveTarget(GameObject target)
	{
		targets.Remove(target);
	}
	}
}

