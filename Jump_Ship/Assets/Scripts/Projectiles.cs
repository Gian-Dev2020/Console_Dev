using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] Rigidbody ball;
    [SerializeField] Transform target;
    [SerializeField] GameObject player;
    [SerializeField] SphereCollider ball_collider;

    // The height 
    [SerializeField] float h = 25; // height arc
    [SerializeField] float gravity = -18;
    [SerializeField] bool debug_path;

    [SerializeField] Trajectory_Line trajectory_line;

    private void Start()
    {
        ball.useGravity = false;
        target.position = player.transform.position;
        target.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {

            trajectory_line.ShowTrajectory(ball.position, ball.velocity);

            if (Input.GetKey(KeyCode.Space))
            {
                target.Translate(0, 0, 0.05f);

            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Launch();
            }
        }

    }

    void Launch()
    {
        if (!ball.IsDestroyed())
        {
            ball.velocity = CalculateLaunchData().initial_velocity;
            target.gameObject.SetActive(true);
            Physics.gravity = Vector3.up * gravity;
            ball.useGravity = true;

        }

        return;

    }

    LaunchData CalculateLaunchData()
    {
        float displacement_y = target.position.y - ball.position.y;
        float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacement_y - h) / gravity);
        Vector3 displacement_xz = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);

        Vector3 velocity_y = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 velocity_xz = displacement_xz / time;

        return new LaunchData(velocity_xz + velocity_y * -Mathf.Sign(gravity), time);
    }

    void DrawPath()
    {
        LaunchData launch_data = CalculateLaunchData();
        Vector3 previous_draw_point = ball.position;

        int resolution = 30;
        for (int i = 1; i <= resolution; i++)
        {
            float simulation_time = i / (float)resolution * launch_data.time_to_target;
            Vector3 displacement = launch_data.initial_velocity * simulation_time + Vector3.up * gravity * simulation_time * simulation_time / 2f;
            Vector3 draw_point = ball.position + displacement;

            previous_draw_point = draw_point;
        }
    }


    struct LaunchData
    {
        public readonly Vector3 initial_velocity;
        public readonly float time_to_target;

        public LaunchData(Vector3 _initial_velocity, float _time_to_target)
        {
            this.initial_velocity = _initial_velocity;
            this.time_to_target = _time_to_target;
        }
    }

}
