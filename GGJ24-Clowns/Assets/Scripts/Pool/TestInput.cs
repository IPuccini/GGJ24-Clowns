using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    private Vector3 _startingPosition = Vector3.zero;
    public float offset;
    public ObjectPool cubePool;
    public ObjectPool spherePool;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("'1' button down");
            Debug.Log("Pulling a cube from the pool");

            // GameObject cube = ObjectPool.SharedInstance.GetPooledObject();
            
            GameObject cube = cubePool.GetPooledObject();

            if (cube == null)
            {
                Debug.Log("No more inactive cubes remaining.");
            }
            else
            {
                cube.transform.position = _startingPosition;
                _startingPosition.x += offset;
            
                cube.SetActive(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("'2' button down");
            Debug.Log("Returning a cube to the pool");

            GameObject cube = cubePool.GetPooledObject(true);

            if (cube == null)
            {
                Debug.Log("No more active cubes remaining.");
            }
            else
            {
            _startingPosition.x -= offset;
            cube.SetActive(false);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("'3' button down");
            Debug.Log("Pulling a sphere from the pool");

            // GameObject cube = ObjectPool.SharedInstance.GetPooledObject();
            
            GameObject sphere = spherePool.GetPooledObject();

            if (sphere == null)
            {
                Debug.Log("No more inactive spheres remaining.");
            }
            else
            {
                sphere.transform.position = _startingPosition;
                sphere.transform.position += Vector3.up * offset;

                _startingPosition.x += offset;
            
                sphere.SetActive(true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("'4' button down");
            Debug.Log("Returning a sphere to the pool");

            GameObject sphere = spherePool.GetPooledObject(true);

            if (sphere == null)
            {
                Debug.Log("No more active spheres remaining.");
            }
            else
            {
                _startingPosition.x -= offset;
                sphere.SetActive(false);
            }
        }
    }
}
