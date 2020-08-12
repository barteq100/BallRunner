using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

namespace DefaultNamespace
{
    public class CameraFollow : MonoBehaviour
    {
        
       

        public FollowData[] Data;
        public float CurrentSpeed;
        public Vector3 Offset;
        private float _maxDistance;


        private Transform _target;

        public Transform Target
        { 
            get => _target;
            set {
                _target = value;
                transform.position = _target.position + Offset;
                transform.LookAt(_target);
            }
        }

        private void Awake()
        {
            _maxDistance = Data.Last().Distance;
        }

        private void FixedUpdate()
        {
            
            var currentObjectPosition = Target.position;
            var wantedPosition = currentObjectPosition + Offset;
            var deltaMove = (wantedPosition - transform.position);
            var nDeltaMove = deltaMove.normalized;
            var distance = deltaMove.magnitude;
            var freeMove = nDeltaMove * Math.Max(0, distance - _maxDistance );
            var restOfMove = deltaMove - freeMove;
            var followData = PickData(distance);
            CurrentSpeed = followData.Speed;
            var maxMovementSpeed = followData.Speed * Time.deltaTime;
            var move = restOfMove * maxMovementSpeed;
            transform.position += freeMove + move;
            transform.LookAt(Target);

        }

        private FollowData PickData(float distance)
        {
            var sqrDist = distance * distance;
            for (var i = 0; i < Data.Length; i++)
            {
                var d = Data[i].Distance;
                var dt = d * d ;
                if (sqrDist < dt)
                {
                    return Data[i];
                }
            }
            
            return Data.Last();
        }
    }

    [Serializable]
    public class FollowData
    {
        public float Distance;
        public float Speed;
    }
}