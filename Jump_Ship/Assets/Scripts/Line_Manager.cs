using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Manager : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    Transform[] points;


    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            line.SetPosition(i, points[i].position);
        }
    }

    public void SetupLine(Transform[] points)
    {
        line.positionCount = points.Length;
        this.points = points;
    }
}
