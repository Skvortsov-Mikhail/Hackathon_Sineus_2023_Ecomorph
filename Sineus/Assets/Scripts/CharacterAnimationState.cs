using UnityEngine;

public class CharacterAnimationState : MonoBehaviour
{
    private const float INPUT_CONTROL_LERP = 10f;
    [SerializeField] private CharacterController targetCharacterController;
    [SerializeField] private CharacterMovement characterMovement;


    [SerializeField] private Animator targetAnimator;

    // Нарушаем логику )

    [SerializeField] private AudioSource audioSource;

    private Vector3 inputControl;
    private bool isPickup;


    private void LateUpdate()
    {
        Vector3 movementSpeed = transform.InverseTransformDirection(targetCharacterController.velocity);
        inputControl = Vector3.MoveTowards(inputControl, characterMovement.TargetDirectionControl, Time.deltaTime * INPUT_CONTROL_LERP);
        targetAnimator.SetFloat("NormolizeMovementX", inputControl.x);
        targetAnimator.SetFloat("NormolizeMovementZ", inputControl.z);
        targetAnimator.SetBool("isPickup", isPickup);

        SpeedSound(inputControl.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Trash trash))
        {
            isPickup = true;
        }
        else
            isPickup = false;
    }

    //TODO вычисления питча от скорости форварда. 
    private void SpeedSound(float speed)
    {
        if (speed < 0.34f)
            audioSource.pitch = Mathf.Lerp(1, audioSource.pitch, Time.deltaTime);
        else
        audioSource.pitch = Mathf.Lerp(audioSource.pitch, speed / 0.34f, Time.deltaTime) ;
    }
}
