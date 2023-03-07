using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Trajectory_Line : MonoBehaviour
{
    [SerializeField] LineRenderer line_renderer;

    [SerializeField, Min(3)] int line_segments = 60;

    [SerializeField, Min(1)] float time_of_flight = 5;

    public void ShowTrajectory(Vector3 start_point, Vector3 start_velocity)
    {
        float time_step = time_of_flight / line_segments;

        Vector3[] line_renderer_points = CalculateLineTrajectory(start_point, start_velocity, time_step);

        line_renderer.positionCount = line_segments;
        line_renderer.SetPositions(line_renderer_points);
    }

    Vector3[] CalculateLineTrajectory(Vector3 start_point, Vector3 start_velocity, float time_step)
    {
        Vector3[] line_renderer_points = new Vector3[line_segments];

        line_renderer_points[0] = start_point;

        for (int i = 1; i < line_segments; i++)
        {
            float time_offset = time_step * i;

            Vector3 progress_before_gravity = start_velocity * time_offset;
            Vector3 gravity_offset = Vector3.up * -0.5f * Physics.gravity.y * time_offset * time_offset;
            Vector3 new_position = start_point + progress_before_gravity - gravity_offset;
            line_renderer_points[i] = new_position;
        }

        return line_renderer_points;
    }

}