using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speedFly;

    private CharacterController characterController;
    public Vector3 TargetDirectionControl;
    public Vector3 DirectionControl;
    private Vector3 movementDirections;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (ÑharacterizationEcomorf.Instance.SpeedChar > 5)
            speedFly = speedFly  + (ÑharacterizationEcomorf.Instance.SpeedChar - 5) + 4;

    }

    private void Update()
    {                
        Move();
    }

    private void Move()
    {
        //DirectionControl = Vector3.MoveTowards(DirectionControl, TargetDirectionControl, Time.fixedDeltaTime);



        movementDirections = TargetDirectionControl * speedFly * Time.deltaTime;

        movementDirections = transform.TransformDirection(movementDirections);

       // movementDirections += Physics.gravity * Time.deltaTime;

        characterController.Move(movementDirections );
    }
}