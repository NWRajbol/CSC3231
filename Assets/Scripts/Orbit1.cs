using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit1 : MonoBehaviour
{
    public GameObject rock1;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround();
    }

    void OrbitAround()
    {
        transform.RotateAround(rock1.transform.position, Vector3.right, speed * Time.deltaTime);
    }
}
