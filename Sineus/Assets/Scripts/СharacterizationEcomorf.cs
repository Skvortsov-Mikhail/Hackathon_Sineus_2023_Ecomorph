
using UnityEngine;
using UnityEngine.SceneManagement;

public class ÑharacterizationEcomorf : SingletonBase<ÑharacterizationEcomorf>
{
    // èíêàïóñëÿöèÿ  âûøëà èç ïğîåêòà.
    public int SpeedChar { get; private set; } = 5;
    public int HillChar { get; private set; } = 5;
    public int AgilityChar { get; private set; } = 5;
    public int AdapticChar { get; private set; } = 5;

     [SerializeField]public int Score;

    private LevelController levelController;
    private bool isLevelScene;
    private void Start()
    {

        SceneManager.activeSceneChanged += Initialization;

        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            isLevelScene = false;
        }
        else
        {
            isLevelScene = true;
            levelController = FindAnyObjectByType<LevelController>();
        }
            


    }

    void Initialization(Scene current, Scene next)
    {

        SetScore();
    }
        public bool AddSpeedChar()
    {
        if (DrawScoree() == true)
        {
            SpeedChar++;
            return true;
        }
           
        else
            return false;
        
    }     
    public bool AddHillChar()
    {
        if (DrawScoree() == true)
        {
            HillChar++;
            return true;
        }
            
        else
            return false;

    }    
    public bool AddAgilityChar()
    {
        if (DrawScoree() == true)
        {
            AgilityChar++;
            return true;
        }
            
        else
            return false;

    }
    public bool AdddapticChar()
    {
        if (DrawScoree() == true)
        {
            AdapticChar++;
            return true;
        }
           
        else
            return false;
    }

    public bool DrawSpeedChar(int num)
    {
        if (num > 5)
        {
            SpeedChar--;
            Score++;
            return true;
        }

        else
            return false;

    }
    public bool DrawHillChar(int num)
    {
        if (num > 5)
        {
            HillChar--;
            Score++;
            return true;
        }

        else
            return false;

    }
    public bool DrawAgilityChar(int num)
    {
        if (num > 5)
        {
            AgilityChar--;
            Score++;
            return true;
        }

        else
            return false;

    }
    public bool DrawAdapticChar(int num)
    {
        if (num > 5)
        {
            AdapticChar--;
            Score++;
            return true;
        }

        else
            return false;
    }



    private bool DrawScoree()
    {
        if (Score > 0)
        {
            Score--;
            return true;
        }
        else
            return false;
          
    }


    private void SetScore()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            isLevelScene = false;
        }
        else
        {
            isLevelScene = true;
            levelController = FindAnyObjectByType<LevelController>();
        }
    }


    private void Update()
    {

        if (isLevelScene == true)
        {
            Score = levelController.Score;
        }
    }

}
