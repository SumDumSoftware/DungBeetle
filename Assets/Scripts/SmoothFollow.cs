﻿using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    #region Consts
    private const float SMOOTH_TIME = 0.3f; 
    #endregion

    #region Public Properties
    public bool LockX;
    public bool LockY;
    public bool LockZ;
    public bool useSmoothing;
    //public Transform target; 
    #endregion

    #region Private Properties
    private Transform thisTransform;
    private Vector3 velocity; 
    #endregion

    private void Awake()
    {
        thisTransform = transform;

        velocity = new Vector3(0.5f, 0.5f, 0.5f);
    }

// ReSharper disable UnusedMember.Local
    private void LateUpdate()
// ReSharper restore UnusedMember.Local
    {
		GameObject pt = GameObject.Find("PlayerTurd");
		if(pt != null)
		{
		Transform target = pt.transform;
        var newPos = Vector3.back;

        if (useSmoothing)
        {
            newPos.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref velocity.x, SMOOTH_TIME);
            newPos.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, ref velocity.y, SMOOTH_TIME);
            newPos.z = Mathf.SmoothDamp(thisTransform.position.z, target.position.z, ref velocity.z, SMOOTH_TIME);
        }
        else
        {
            newPos.x = target.position.x;
            newPos.y = target.position.y;
            newPos.z = target.position.z;
        }

        #region Locks
        if (LockX)
        {
            newPos.x = thisTransform.position.x;
        }

        if (LockY)
        {
            newPos.y = thisTransform.position.y;
        }

        if (LockZ)
        {
            newPos.z = thisTransform.position.z;
        } 
        #endregion

        	transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
			transform.Translate(Vector3.back * 0.5f);
		}
    }
}
