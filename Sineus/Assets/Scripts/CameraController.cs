using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float distanceCamera;
    [SerializeField] private float minDistanceCamera;
    [SerializeField] private float maxDistanceCamera;


    [SerializeField] private float sensetive;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float offsetLerpRate;
    [SerializeField] private float rotateTargetLerpRate;

    [Header("RotationLimit")]
    [SerializeField] private float maxAngleLimitY;
    [SerializeField] private float minAngleLimitY;


    [SerializeField] private float minDistance;
    [SerializeField] private float distanceLerpRate;
    [SerializeField] private float distanceOffsetFromCollisionHit;

    [HideInInspector] public bool IsRotateTarget;
    [HideInInspector] public Vector3 rotateControl;

    private float deltaRotationX;
    private float deltaRotationY;

    private float currentDistance;

    private Vector3 targetOffset;

    private void Start()
    {
        if (�haracterizationEcomorf.Instance.AgilityChar > 5)
        {
            rotateTargetLerpRate = rotateTargetLerpRate + (�haracterizationEcomorf.Instance.AgilityChar - 5) + 100;
        }    
            targetOffset = offset;
    }
    private void Update()
    {
        deltaRotationX += rotateControl.x * sensetive;
        deltaRotationY += rotateControl.y * sensetive;


        deltaRotationY = ClampAngle(deltaRotationY, minAngleLimitY, maxAngleLimitY);

        offset = Vector3.MoveTowards(offset, targetOffset, Time.deltaTime * offsetLerpRate);

        Quaternion finalRotation = Quaternion.Euler(-deltaRotationY, deltaRotationX, 0);
        Vector3 finalPosition = target.position - (finalRotation * Vector3.forward * distanceCamera);
        finalPosition = AddLocalOffset(finalPosition);

        //Calculate current distance
        float targetDistance = distanceCamera;
        RaycastHit hit;

        if (Physics.Linecast(target.position + new Vector3(0, offset.y, 0), finalPosition, out hit) == true && hit.collider.isTrigger == false )
        {
            float distanceToHit = Vector3.Distance(target.position + new Vector3(0, offset.y, 0), hit.point);

            if (hit.transform != target)
            {
                if (distanceToHit < distanceCamera)
                    targetDistance = distanceToHit - distanceOffsetFromCollisionHit;
            }
        }

        currentDistance = Mathf.MoveTowards(currentDistance, targetDistance, Time.deltaTime * distanceLerpRate);
        currentDistance = Mathf.Clamp(currentDistance, minDistance, distanceCamera);

        //Correct camera position
        finalPosition = target.position - (finalRotation * Vector3.forward * currentDistance);

        //Apply transform
        transform.rotation = finalRotation;
        transform.position = finalPosition;
        transform.position = AddLocalOffset(finalPosition);

        if (IsRotateTarget == true)
        {
            Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.rotation.z);
            target.rotation = Quaternion.RotateTowards(target.rotation, targetRotation, Time.deltaTime * rotateTargetLerpRate);
        }
    }

    public void ScrollDistanceCamera(float distanse)
    {
        distanceCamera = Mathf.Clamp(distanceCamera + distanse * sensetive, minDistanceCamera, maxDistanceCamera);
    }

    private Vector3 AddLocalOffset(Vector3 position)
    {
        Vector3 result = position;
        result += new Vector3(0, offset.y, 0);
        result += transform.right * offset.x;
        result += transform.forward * offset.z;

        return result;
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;

        if (angle > 360)
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
