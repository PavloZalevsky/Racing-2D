using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PleyerCarScript : MonoBehaviour
{
    public int Speed { get; set; }
    public int NitroSpeed { get; set; }
    public float NitroTime { get; set; }

    public Image NitroBar;

    private float curentNitroTimer = 0;
    private bool nitro = false;
    private float unitLossNitro;
    private WheelJoint2D[] wheelJoints;
    private JointMotor2D motorBack;
    private float torqueDir = 0f;

    void Start()
    {   
        unitLossNitro = 0.999f / (NitroTime / 0.1f); // рахується скільки з nitrobar одиниць беде забираться за 0.1s
        curentNitroTimer = NitroTime;
        wheelJoints = gameObject.GetComponents<WheelJoint2D>();
        motorBack = wheelJoints[0].motor;
        motorBack.motorSpeed = Speed; // скорость машини

        wheelJoints[0].motor = motorBack;
        wheelJoints[1].motor = motorBack;
    }

    void FixedUpdate()
    {
        torqueDir = Input.GetAxis("Horizontal");
        if (torqueDir != 0)
        {
            GetComponent<Rigidbody2D>().AddTorque(110 * Mathf.PI * torqueDir * -1, ForceMode2D.Force);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddTorque(0);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && curentNitroTimer > 0)
        {
            if (!nitro)
            {
                StartCoroutine("Nitro");
                nitro = true;
            }
            motorBack.motorSpeed = NitroSpeed;   
        }
        else
        {
            nitro = false;
            StopAllCoroutines();
            motorBack.motorSpeed = Speed;
        }

        wheelJoints[0].motor = motorBack;
        wheelJoints[1].motor = motorBack;  
    }

    public IEnumerator Nitro()
    {
        while(curentNitroTimer >= 0 && Input.GetKey(KeyCode.UpArrow))
        {
            NitroBar.fillAmount -= unitLossNitro;
            curentNitroTimer -= 0.1f;
           yield return new WaitForSeconds(0.1f);
        }
    }
}