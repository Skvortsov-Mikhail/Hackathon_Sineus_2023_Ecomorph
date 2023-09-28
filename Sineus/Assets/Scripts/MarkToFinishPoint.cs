using System;
using UnityEngine;
using Zenject;

public class MarkToFinishPoint : MonoBehaviour
{
    public Action<bool> OnMarkAchieved;

    private LevelController _levelController;

    private bool _isTrashCollected = false;

    private AudioSource _audioSource;

    [Inject]
    public void Construct(LevelController levelController)
    {
        _levelController = levelController;
    }

    private void Start()
    {
        _levelController.OnAllTrashCollected += StartFinishStage;
        //_audioSource = GetComponent<AudioSource>();
        //_audioSource.enabled = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _levelController.OnAllTrashCollected -= StartFinishStage;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (_isTrashCollected == false) return;

        var character = other.transform.root.GetComponent<CharacterMovement>();

        if (character != null)
        {
            OnMarkAchieved?.Invoke(true);
            _isTrashCollected = false;
        }
    }

    public void StartFinishStage(bool result)
    {
        gameObject.SetActive(result);
        _isTrashCollected = result;
        //_audioSource.enabled = true;
    }
}
