using UnityEngine;

public class Organic : MonoBehaviour
{
    [SerializeField] private ItemType m_type;
    public ItemType Type => m_type;

    [SerializeField] private ImpactEffect m_ImpactEffect;

    [SerializeField] private ShieldEffect m_ShieldEffect;

    [SerializeField] private float m_StopZoneTime = 1;


    private void Start()
    {
        if (m_ShieldEffect != null)
        {
            var shield = Instantiate(m_ShieldEffect, transform.position, Quaternion.identity);

            shield.SetLifeTime(m_StopZoneTime);
        }

        if (m_ImpactEffect != null)
        {
            var impactEffect = Instantiate(m_ImpactEffect, transform.position, Quaternion.identity);
        }
    }
}
