using TMPro;
using UnityEngine;
using Zenject;

public class UIReworked : MonoBehaviour
{
    [SerializeField] private TMP_Text _reworkedTrashCountText;

    [SerializeField] private TMP_Text _needTrashCountText;

    [SerializeField] private GameObject m_timerCompas;

    private GameManager _gameManager;
    private LevelController _levelController;

    private int _winCount;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager, LevelController levelController)
    {
        _gameManager = gameManager;
        _levelController = levelController;
    }

    private void Awake()
    {
        _levelController.OnAllTrashCollected += SetTimerCompasVisibility;
        _gameManager.OnReworked += UpdateText;
    }
    private void OnDestroy()
    {
        _levelController.OnAllTrashCollected -= SetTimerCompasVisibility;
        _gameManager.OnReworked -= UpdateText;
    }

    private void Start()
    {
        _winCount = _levelController.TrashWinCount;

        UpdateText(0);

        m_timerCompas.SetActive(false);
    }

    private void UpdateText(int count)
    {
        _reworkedTrashCountText.text = count.ToString();
        _needTrashCountText.text = _winCount.ToString();

        if (count > _winCount)
        {
            _reworkedTrashCountText.color = new Color(0.61f, 0.86f, 0.6f);
        }
    }

    private void SetTimerCompasVisibility(bool result)
    {
        m_timerCompas.SetActive(result);
    }
}
