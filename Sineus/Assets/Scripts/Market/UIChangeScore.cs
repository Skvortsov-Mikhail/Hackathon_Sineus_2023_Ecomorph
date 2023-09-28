using TMPro;
using UnityEngine;

public class UIChangeScore : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;

    private void Update()
    {
        m_Text.text = ÑharacterizationEcomorf.Instance.Score.ToString();
    }
}
