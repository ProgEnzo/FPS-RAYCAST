using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Cube")]
    [SerializeField] private GameObject[,,] _gameObjects;
    public GameObject Cubix;

    [Header("Parameters")]
    public float offset = 2f;
    public int sizeX;
    public int sizeY;
    public int sizeZ;
    
    [Header("Material")]
    public Material wMat;
    public Material bMat;
    private void Start()
    {
       _gameObjects = new GameObject[sizeX, sizeY, sizeZ];

       for (int x = 0; x < _gameObjects.GetLength(0); x++)
       {
           for (int y = 0; y < _gameObjects.GetLength(1); y++)
           {
               for (int z = 0; z < _gameObjects.GetLength(1); z++)
               { 
                   _gameObjects[x, y, z] = Instantiate(Cubix, new Vector3(x * offset, y * offset, z * offset), Quaternion.identity);

                   if (x % 2 == 0 && y % 2 == 1 || x % 2 == 1 && y % 2 == 0)
                   {
                       if (z%2 == 0)
                       {
                           _gameObjects[x, y, z].GetComponent<Renderer>().material = wMat;
                       }
                   }
                   else
                   {
                       if (z%2 == 1)
                       {
                           _gameObjects[x, y, z].GetComponent<Renderer>().material = wMat;
                       }
                   }
                       
               }
               

           }
       }
    }
    
}





