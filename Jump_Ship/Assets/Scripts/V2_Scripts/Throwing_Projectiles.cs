using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwing_Projectiles : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    [SerializeField] Transform target_position;
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody stone;

    [SerializeField]
    [Range(10, 100)]
    int line_points = 25;

    [SerializeField]
    [Range(0.01f, 0.25f)]
    float time_between_points = 0.1f;

    [SerializeField] float throw_strength = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DrawProjection();
    }

    void DrawProjection()
    {
        line.enabled = true;
        line.positionCount = Mathf.CeilToInt(line_points / time_between_points) + 1;

        Vector3 start_pos = target_position.position;
        Vector3 start_velocity = throw_strength * cam.transform.forward / stone.mass;

        int i = 0;
        line.SetPosition(i, start_pos);

        for (float time = 0; time < line_points; time += time_between_points)
        {
            i++;

            Vector3 point = start_pos + time * start_velocity;
            point.y = start_pos.y + start_velocity.y * time + (Physics.gravity.y / 2f * time * time);

            line.SetPosition(i, point);
        }

    }
}
