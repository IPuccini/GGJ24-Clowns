using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    private Vector3 _startingPosition = Vector3.zero;
    public float offset;

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

            GameObject cube = ObjectPool.SharedInstance.GetPooledObject();
            
            if (cube == null)
            {
                Debug.Log("No more inactive objects remaining.");
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

            GameObject cube = ObjectPool.SharedInstance.GetPooledObject(true);

            if (cube == null)
            {
                Debug.Log("No more active objects remaining.");
            }
            else
            {
            _startingPosition.x -= offset;
            cube.SetActive(false);
            }
        }

    }
}
