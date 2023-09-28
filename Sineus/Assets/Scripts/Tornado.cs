using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private int m_damage = 1;
    [SerializeField] private float m_hitRate = 1;

    private bool _canHit;
    private float _timer;

    private void Start()
    {
        //m_damage = m_damage - (ÑharacterizationEcomorf.Instance.AdapticChar - 5) - 5;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= m_hitRate)
        {
            _canHit = true;

            _timer = 0;
        }
        else
        {
            _canHit = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var player = other.transform.GetComponent<PlayerHP>();

        if (player != null && _canHit == true)
        {
            player.RemoveHealth(m_damage);
        }
    }
}
