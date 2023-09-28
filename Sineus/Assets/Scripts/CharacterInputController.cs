using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInputController : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Transform target;
    [SerializeField] private float verticalSpeed;

    [SerializeField] private CameraController targetCamera;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        characterMovement.TargetDirectionControl.x = Input.GetAxis("Horizontal");
        characterMovement.TargetDirectionControl.z = Input.GetAxis("Vertical");

        if (targetCamera == null) return;

        targetCamera.rotateControl = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        targetCamera.ScrollDistanceCamera(Input.GetAxis("Mouse ScrollWheel"));

        if (characterMovement.TargetDirectionControl != Vector3.zero )
        {
            targetCamera.IsRotateTarget = true;
        }
        else
            targetCamera.IsRotateTarget = false;
    }
}
