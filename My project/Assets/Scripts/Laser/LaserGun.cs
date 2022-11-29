using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using RaycastHit = UnityEngine.RaycastHit;

public class LaserGun : MonoBehaviour
{ 
   
   [Header("RAYCAST")]
   Vector3 origin;
   Vector3 direction;
   [SerializeField] float lenght;
   [SerializeField] int maxBounce = 3;
   [SerializeField] float maxDistance = 100; 
   [SerializeField] private int currentBounceNumber = 0;
   public LineRenderer lr;
   
   public List<Vector3> points = new ();

   [Header("Sphere")] 
   [SerializeField] private float currentSphereSpeed;
   [SerializeField] private float sphereSpeed = 5f;
   public GameObject sphere;
   public MeshRenderer sphereMesh;
   [SerializeField] Rigidbody rb;
   public bool sphereTouched;
   
   [Header("Player")]
   public rotationController rc;
   
   [Header("Walls")]
   public GameObject wall1;
   public GameObject wall2;
   public GameObject wall3;
   public GameObject wall4;

   private void Update()
   {
      sphereTouched = false;
      currentBounceNumber = points.Count - 2;
      currentSphereSpeed = sphereSpeed * currentBounceNumber;

      CrossWalls();
      
      points.Clear();
      points.Add(rc.head.transform.position);

      DoRay(rc.head.transform.position, transform.forward, maxBounce, maxDistance);
      
      lr.positionCount = points.Count;
      lr.SetPositions(points.ToArray());

      if (sphereTouched == true)
      {
         sphereMesh.material.color = Color.green;
      }
      else
      {
         sphereMesh.material.color = Color.grey;
         sphere.GetComponent<Rigidbody>().velocity = Vector3.zero; 
      }
   }

   private void CrossWalls()
   {
      if (sphereTouched == true)
      {
         if (currentBounceNumber >= 1)
         {
            wall1.GetComponent<MeshCollider>().enabled = false;
         }
         else if (currentBounceNumber >= 2)
         {
            
         }
         else if (currentBounceNumber >= 4)
         {
            
         }
         else if (currentBounceNumber >= 5)
         {
            
         }
      }
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
            
            MeshRenderer mesh = hit.transform.GetComponent<MeshRenderer>(); //How To Recup uniquement celui d'un certain objet et le réinit une fois que le Raycast n'est plus en collision avec l'objet
            
            if(hit.transform.CompareTag("MovingSphere"))
            {
               sphereTouched = true;

               Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
               
               if (sphereTouched == true)
               {
                  rb.velocity = new Vector3(0, 0, currentSphereSpeed); //use Velocity instead of AddForce
               }
            }

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
