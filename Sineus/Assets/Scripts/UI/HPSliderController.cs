using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HPSliderController : MonoBehaviour
{
    [SerializeField] private Image m_HPProgressBar;

    [SerializeField] private Color m_fatalColor;

    [SerializeField] private Color m_fullColor;

    private PlayerHP _playerHP;

    [Inject]

    public void Construct(PlayerHP playerHP)
    {
        _playerHP = playerHP;
    }

    private void Start()
    {
        m_HPProgressBar.fillAmount = 1;

        _playerHP.OnCurrentHPUpdate += UpdateHPProgress;
    }

    public void UpdateHPProgress(float currentHP)
    {
        m_HPProgressBar.fillAmount = currentHP;

        m_HPProgressBar.color = Color.Lerp(m_fatalColor, m_fullColor, m_HPProgressBar.fillAmount);
    }

    private void OnDestroy()
    {
        _playerHP.OnCurrentHPUpdate -= UpdateHPProgress;
    }
}
