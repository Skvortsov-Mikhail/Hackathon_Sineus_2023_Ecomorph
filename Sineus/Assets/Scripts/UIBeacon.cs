using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIBeacon : MonoBehaviour
{
    [SerializeField] private float timeDurationOfFinish;

    [SerializeField] private float leftAngle = 40;
    [SerializeField] private float rightAngle = -40;

    [SerializeField] private Image leftArrow;
    [SerializeField] private Image rightArrow;
    [SerializeField] private TMP_Text timerText;

    private MarkToFinishPoint _markToFinishPoint;
    private LevelController _levelController;

    private float angle;

    private bool _isFinishStage;

    private Timer timer;


    [Inject]
    public void Construct(MarkToFinishPoint markToFinishPoint, LevelController levelController)
    {
        _markToFinishPoint = markToFinishPoint;
        _levelController = levelController;
    }

    private void Start()
    {
        _levelController.OnAllTrashCollected += StartFinishStage;
    }

    private void Update()
    {
        if (_isFinishStage == true)
            MarkBeacon();
    }

    private void OnDestroy()
    {
        if(_levelController != null)
        _levelController.OnAllTrashCollected -= StartFinishStage;
    }

    private void MarkBeacon()
    {
        Vector3 targetDir = _markToFinishPoint.transform.position - transform.position;
        angle = Vector3.SignedAngle(targetDir, transform.forward,Vector3.up);
        if (angle > leftAngle)
        {
            leftArrow.enabled = true;
            rightArrow.enabled = false;
        }
        else if (angle < rightAngle)
        {
            leftArrow.enabled = false;
            rightArrow.enabled = true;
        }
        else 
        {
            leftArrow.enabled = false;
            rightArrow.enabled = false;
        }

        timerText.text = StringTime.SecondToTimeString(timer.CurrentTime);
        if(timer.CurrentTime < 15)
            timerText.color = Color.red;
    }

    private void StartFinishStage(bool result)
    {
        _isFinishStage = result;

        timer = Timer.CreateTimer(timeDurationOfFinish, false);

        timer.OnTimeRanOut += TimeOver;

        _levelController.OnAllTrashCollected -= StartFinishStage;
    }

    private void TimeOver()
    {
        _levelController.TimeOver();
    }
}
