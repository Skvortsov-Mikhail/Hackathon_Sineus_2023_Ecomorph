using System;
using UnityEngine;
using Zenject;

public class KillZoneController : MonoBehaviour
{
    [SerializeField] private int m_damage = 1;

    [SerializeField] private float m_hitRate = 1;

    private PlayerHP _playerHP;

    private bool _isInZone;
    public bool IsInZone => _isInZone;

    private float _timer;

    private KillZone _killZone;
    public KillZone GetKillZone() { if (_killZone) return _killZone; else return null; }

    [Inject]
    public void Construct(PlayerHP playerHP)
    {
        _playerHP = playerHP;
    }

    private void Start()
    {
        if (ÑharacterizationEcomorf.Instance.SpeedChar > 5)
        {
            m_damage = m_damage - (ÑharacterizationEcomorf.Instance.AdapticChar - 5) - 5;
        }
    }

    private void Update()
    {
        if (_isInZone == true) return;

        _timer += Time.deltaTime;

        if (_timer >= m_hitRate)
        {
            _playerHP.RemoveHealth(m_damage);
            _timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out KillZone killZone))
        {
            _killZone = killZone;
            _isInZone = true;
        }
        else
        {
            _killZone = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out KillZone killZone))
        {
            _killZone = killZone;
            _isInZone = false;
        }
        else
        {
            _killZone = null;
        }
    }
}
