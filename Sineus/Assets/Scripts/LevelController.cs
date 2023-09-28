using System;
using UnityEngine;
using Zenject;

public class LevelController : MonoBehaviour
{
    public Action<bool> OnAllTrashCollected;
    public Action<bool> OnFinishLevel;

    [SerializeField] private int m_TrashWinCount;
    public int TrashWinCount => m_TrashWinCount;

    private GameManager _gameManager;
    private PlayerHP _playerHP;
    private MarkToFinishPoint _markToFinishPoint;

    private int _score;
    public int Score => _score;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager, PlayerHP playerHP, MarkToFinishPoint markToFinishPoint)
    {
        _gameManager = gameManager;
        _playerHP = playerHP;
        _markToFinishPoint = markToFinishPoint;
    }

    private void Awake()
    {
        _gameManager.OnReworked += CheckWin;
        _playerHP.OnPlayerDeath += LoseLevel;
        _markToFinishPoint.OnMarkAchieved += FinishLevel;
        _score = 0;
    }

    private void OnDestroy()
    {
        _gameManager.OnReworked -= CheckWin;
        _playerHP.OnPlayerDeath -= LoseLevel;
        _markToFinishPoint.OnMarkAchieved -= FinishLevel;
    }

    private void CheckWin(int score)
    {
        _score = score;

        if (score >= m_TrashWinCount)
        {
            _gameManager.LevelCompleted();
            OnAllTrashCollected?.Invoke(true);
        }
    }

    private void LoseLevel()
    {
        OnFinishLevel?.Invoke(false);
    }

    private void FinishLevel(bool result)
    {
        OnFinishLevel?.Invoke(result);
    }

    public void TimeOver()
    {
        LoseLevel();
    }
}
