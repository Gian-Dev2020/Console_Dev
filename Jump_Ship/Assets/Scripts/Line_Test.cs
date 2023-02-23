using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Test : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] Line_Manager line_manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        line_manager.SetupLine(points);
    }
}
