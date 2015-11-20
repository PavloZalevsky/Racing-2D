using UnityEngine;
using System.Collections;

public class EnemyCarScript : MonoBehaviour
{
    public int Speed { get; set; }
    public int NitroSpeed { get; set; }
    public float NitroTime { get; set; }
    public Transform RealWheel;
    public Transform FrontWhel;
    public Transform groundCheck;
    public float groundRadius = 0.5f;
    public LayerMask whatIsGround;

    private float curentNitroTimer;
    private WheelJoint2D[] wheelJoints;
    private JointMotor2D motorBack;
    private Rigidbody2D rigidbody2D;
    private bool grounded = false;
    private float time;
    private bool nitro = false;

    void Start()
    {
        curentNitroTimer = NitroTime;
        rigidbody2D = GetComponent<Rigidbody2D>();
        wheelJoints = GetComponents<WheelJoint2D>();
        motorBack = wheelJoints[0].motor;
        motorBack.motorSpeed = Speed; // скорость машини

        wheelJoints[0].motor = motorBack;
        wheelJoints[1].motor = motorBack;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);  // чі ми назем

        RaycastHit2D hit1 = Physics2D.Raycast(RealWheel.position, -transform.up, 50, 9);
        RaycastHit2D hit2 = Physics2D.Raycast(FrontWhel.position, -transform.up, 50, 9);
        RaycastHit2D right = Physics2D.Raycast(RealWheel.position, transform.right, 50, 9);
        RaycastHit2D left = Physics2D.Raycast(FrontWhel.position, -transform.right, 50, 9);

        if (right.collider != null && !grounded)
        {
            rigidbody2D.AddTorque(190 * Mathf.PI * 1, ForceMode2D.Force);
        }
        if (left.collider != null && !grounded)
        {
            rigidbody2D.AddTorque(190 * Mathf.PI * -1, ForceMode2D.Force);
        }

        if (hit1.collider != null && hit2.collider != null)
        {
            if (hit1.distance > hit2.distance && grounded)
            {
                rigidbody2D.AddTorque(14 * (hit1.distance - hit2.distance) * Mathf.PI * 1, ForceMode2D.Force);
            }
            else if (hit1.distance < hit2.distance && grounded)
            {
                rigidbody2D.AddTorque(14 * (hit2.distance - hit1.distance) * Mathf.PI * -1, ForceMode2D.Force);
            }
        }

        int a = Random.Range(-22, 22); // random nitro
        if (a == 1 && !nitro && curentNitroTimer > 0)
        {
            time = Random.Range(0, curentNitroTimer + 1);
            curentNitroTimer -= time;
            motorBack.motorSpeed = NitroSpeed;
            wheelJoints[0].motor = motorBack;
            wheelJoints[1].motor = motorBack;
            nitro = true;
        }

        if (nitro)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                nitro = false;
                motorBack.motorSpeed = Speed;
                wheelJoints[0].motor = motorBack;
                wheelJoints[1].motor = motorBack;
            }
        }
    }
}

