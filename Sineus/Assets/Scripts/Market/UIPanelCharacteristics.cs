using TMPro;
using UnityEngine;
using UnityEngine.UI;

public  enum TypeChar
{
    
    Speed,
    Agility,
    Hill,
    Adaptic

}

public class UIPanelCharacteristics : MonoBehaviour
{

    [SerializeField] private Button buttonUp;
    [SerializeField] private Image imageUp;
    [SerializeField] private Image imageDown;
    [SerializeField] private Button buttonDown;
    [SerializeField] private TMP_Text numTextChar;

    [SerializeField] private TypeChar typeChar;

    private int numChar;

    private void Start()
    {
        switch (typeChar)
        {
            case TypeChar.Speed:
                numChar = —haracterizationEcomorf.Instance.SpeedChar;
                break;
            case TypeChar.Agility:
                numChar = —haracterizationEcomorf.Instance.AgilityChar;
                break;
            case TypeChar.Hill:
                numChar = —haracterizationEcomorf.Instance.HillChar;
                break;
            case TypeChar.Adaptic:
                numChar = —haracterizationEcomorf.Instance.AdapticChar;
                break;

        }

        numTextChar.text = numChar.ToString();
    }

    private int num2;

    private void Type()
    {
               switch (typeChar)
        {
            case TypeChar.Speed:
                num2 = —haracterizationEcomorf.Instance.SpeedChar;
                break;
            case TypeChar.Agility:
                num2 = —haracterizationEcomorf.Instance.AgilityChar;
                break;
            case TypeChar.Hill:
                num2 = —haracterizationEcomorf.Instance.HillChar;
                break;
            case TypeChar.Adaptic:
                num2 = —haracterizationEcomorf.Instance.AdapticChar;
                break;

        }
    }
        
    public void ClickButtonUp()
    {
        if (TypeChar.Speed == typeChar &&  —haracterizationEcomorf.Instance.AddSpeedChar())
        {
            numChar++;
            numTextChar.text = numChar.ToString();
        }
        if (TypeChar.Agility == typeChar && —haracterizationEcomorf.Instance.AddAgilityChar())
        {
            numChar++;
            numTextChar.text = numChar.ToString();
        }
        if (TypeChar.Hill == typeChar && —haracterizationEcomorf.Instance.AddHillChar())
        {
            numChar++;
            numTextChar.text = numChar.ToString();
        }
        if (TypeChar.Adaptic == typeChar && —haracterizationEcomorf.Instance.AdddapticChar())
        {
            numChar++;
            numTextChar.text = numChar.ToString();
        }
    }

    public void ClickButtonDown()
    {
        if (TypeChar.Speed == typeChar && —haracterizationEcomorf.Instance.DrawSpeedChar(numChar))
        {
            numChar --;
            numTextChar.text = numChar.ToString();
        }        
        
        if (TypeChar.Agility == typeChar && —haracterizationEcomorf.Instance.DrawAgilityChar(numChar))
        {
            numChar --;
            numTextChar.text = numChar.ToString();
        }       
        
        if (TypeChar.Hill == typeChar && —haracterizationEcomorf.Instance.DrawHillChar(numChar))
        {
            numChar --;
            numTextChar.text = numChar.ToString();
        }       
        
        if (TypeChar.Adaptic == typeChar && —haracterizationEcomorf.Instance.DrawAdapticChar(numChar))
        {
            numChar --;
            numTextChar.text = numChar.ToString();
        }
    }

    //“‡ÍÓÂ Ò‚ËÌÒÚ‚Ó ‰Îˇ UI ˇ Â˘Â ÌÂ ‰ÂÎ‡Î....
    private void Update()
    {
        if (—haracterizationEcomorf.Instance.Score <= 0)
        {
            buttonUp.enabled = false;
            //imageUp.color = new Color(0,0,0, 100);
        }
        else
        {
            buttonUp.enabled = true;
        }

        if (numChar == 5)
        {
            buttonDown.enabled = false;
            //imageUp.color = new Color(0, 0, 0, 100);
        }
        else
        {
            buttonDown.enabled = true;
        }
    }
}
