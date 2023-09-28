using System;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public event Action OnPlayerDeath;
    public event Action<float> OnCurrentHPUpdate;
    private int m_MaxHitPoints = 100;
    private int _currentHP;

    public float NormalizedHP => (float)_currentHP / m_MaxHitPoints;

    private void Start()
    {
        if (ÑharacterizationEcomorf.Instance.HillChar > 5)
        {
            m_MaxHitPoints = m_MaxHitPoints + (ÑharacterizationEcomorf.Instance.HillChar - 5) + 20;
        }
            _currentHP = m_MaxHitPoints;
    }

    public void AddHealth(int value)
    {
        _currentHP += value;

        if (_currentHP > m_MaxHitPoints)
        {
            _currentHP = m_MaxHitPoints;
        }


        OnCurrentHPUpdate?.Invoke(NormalizedHP);
    }

    public void RemoveHealth(int value)
    {
        _currentHP -= value;

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            OnPlayerDeath?.Invoke();
        }

        OnCurrentHPUpdate?.Invoke(NormalizedHP);
    }
}
