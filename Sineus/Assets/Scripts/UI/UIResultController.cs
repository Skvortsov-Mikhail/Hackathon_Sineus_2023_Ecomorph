using TMPro;
using UnityEngine;
using Zenject;

public class UIResultController : MonoBehaviour
{
    [SerializeField] private GameObject m_winPanel;
    [SerializeField] private GameObject m_losePanel;

    [SerializeField] private TMP_Text[] m_finalCountText;

    private GameManager _gameManager;
    private LevelController _levelController;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager, LevelController levelController)
    {
        _gameManager = gameManager;
        _levelController = levelController;
    }

    private void Awake()
    {
        _gameManager.OnLevelCompleted += UpdateFinalCountText;
        _levelController.OnFinishLevel += ShowResultPanel;
    }

    private void OnDestroy()
    {
        _gameManager.OnLevelCompleted -= UpdateFinalCountText;
        _levelController.OnFinishLevel -= ShowResultPanel;
    }

    private void Start()
    {
        m_winPanel.SetActive(false);
        m_losePanel.SetActive(false);
    }

    private void UpdateFinalCountText(int count)
    {
        foreach (var text in m_finalCountText)
        {
            text.text = count.ToString();
        }
    }

    private void ShowResultPanel(bool result)
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (result == true)
        {
            m_winPanel.SetActive(true);
        }

        if (result == false)
        {
            m_losePanel.SetActive(true);
        }

        _gameManager.ResetCount();
    }
}
