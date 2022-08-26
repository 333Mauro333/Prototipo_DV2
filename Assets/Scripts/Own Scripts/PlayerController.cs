using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Setting Values")]
    [Range(0.0f, 15.0f)]
    [SerializeField] float walkSpeed = 0.0f;
    [SerializeField] float rotationSensitivity = 0.0f;

    [SerializeField] bool rightHandedPlayer = true;


    string forwardAxisName = "";
    string leftAxisName = "";
    string rightAxisName = "";
    string backwardAxisName = "";

    string mouseXAxisName = "";

    CharacterController cc = null;



    void Awake()
	{
        forwardAxisName = (rightHandedPlayer) ? "RHPlayerForward" : "LHPlayerForward";
        leftAxisName = (rightHandedPlayer) ? "RHPlayerLeft" : "LHPlayerLeft";
        rightAxisName = (rightHandedPlayer) ? "RHPlayerRight" : "LHPlayerRight";
        backwardAxisName = (rightHandedPlayer) ? "RHPlayerBackward" : "LHPlayerBackward";

        mouseXAxisName = "MouseXAxis";

        cc = GetComponent<CharacterController>();
	}

	void Update()
	{
        Rotation();
	}

	void FixedUpdate()
    {
        Movement();
    }



    void Movement()
	{
        float forwardAxisSpeed = Input.GetAxis(forwardAxisName);
        float leftAxisSpeed = Input.GetAxis(leftAxisName);
        float rightAxisSpeed = Input.GetAxis(rightAxisName);
        float backwardAxisSpeed = Input.GetAxis(backwardAxisName);


        if (forwardAxisSpeed != 0.0f)
		{
            MoveForward();
		}

        if (leftAxisSpeed != 0.0f)
        {
            MoveLeft();
        }

        if (rightAxisSpeed != 0.0f)
        {
            MoveRight();
        }

        if (backwardAxisSpeed != 0.0f)
        {
            MoveBackward();
        }
    }

    void MoveForward()
	{
        float axisSpeed = Input.GetAxis(forwardAxisName);


        cc.Move(transform.forward * axisSpeed * walkSpeed * Time.deltaTime);
	}
    void MoveLeft()
    {
        float axisSpeed = Input.GetAxis(leftAxisName);


        cc.Move(-transform.right * axisSpeed * walkSpeed * Time.deltaTime);
    }
    void MoveRight()
    {
        float axisSpeed = Input.GetAxis(rightAxisName);


        cc.Move(transform.right * axisSpeed * walkSpeed * Time.deltaTime);
    }
    void MoveBackward()
    {
        float axisSpeed = Input.GetAxis(backwardAxisName);


        cc.Move(-transform.forward * axisSpeed * walkSpeed * Time.deltaTime);
    }

    void Rotation()
    {
        float rotateHorizontal = Input.GetAxis(mouseXAxisName);

        
        transform.Rotate(0.0f, rotateHorizontal * rotationSensitivity, 0.0f);
    }
}
