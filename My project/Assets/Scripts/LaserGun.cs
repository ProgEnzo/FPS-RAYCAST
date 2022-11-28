using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using RaycastHit = UnityEngine.RaycastHit;

public class LaserGun : MonoBehaviour
{ 
   Vector3 origin;
   Vector3 direction;
   [SerializeField] float lenght;
   [SerializeField] int maxBounce = 3;
   [SerializeField] float maxDistance = 100;

   public LineRenderer lr;

   public rotationController rc;
   
   public List<Vector3> points = new ();

   private void Update()
   {
      points.Clear();
      points.Add(rc.head.transform.position);
      
      DoRay(rc.head.transform.position, transform.forward, maxBounce, maxDistance);
      
      lr.positionCount = points.Count;
      lr.SetPositions(points.ToArray());
   }

   private void DoRay(Vector3 origin, Vector3 direction, int bounceLeft, float distance)
   {
      RaycastHit hit;

      if (bounceLeft != 0)
      {
         if (Physics.Raycast(origin, direction, out hit, distance))
         {
            //lr.positionCount++;
            Debug.DrawRay(origin, direction * hit.distance, Color.blue, 0f);
                                           
            Vector3 newDirection = Vector3.Reflect(direction, hit.normal);
            //lr.positionCount += 2;
                                           
            Debug.DrawRay(hit.point, newDirection * 2, Color.green, 0f);
         
            bounceLeft--;
            distance -= hit.distance;
            
            points.Add(hit.point);
                  
            DoRay(hit.point, newDirection, bounceLeft, distance);
         }
         else
         {
            Debug.DrawRay(origin, direction * distance, Color.magenta, 0f);
            points.Add(origin + direction * distance);
         }
      }
   }
}
