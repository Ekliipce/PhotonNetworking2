using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += Random.insideUnitSphere * 4f;   
    }

}
