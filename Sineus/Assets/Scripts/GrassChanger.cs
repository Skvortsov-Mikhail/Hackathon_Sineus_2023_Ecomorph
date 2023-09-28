using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GrassChanger : MonoBehaviour
{
    [SerializeField] private Color m_targetColor = new Color(0.46f, 0.76f, 0.11f);

    private Material _material;
    private Color _startColor;

    private LevelController _levelController;
    private GameManager _gameManager;

    private int _stepsCount;

    private float _redStep;
    private float _greenStep;
    private float _blueStep;


    [Inject]
    public void Construct(LevelController levelController, GameManager gameManager)
    {
        _levelController = levelController;
        _gameManager = gameManager;
    }

    private void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        _startColor = _material.color;

        _stepsCount = _levelController.TrashWinCount;
        _gameManager.OnReworked += SwitchColor;

        _redStep = (m_targetColor.r - _startColor.r) / _stepsCount;
        _greenStep = (m_targetColor.g - _startColor.g) / _stepsCount;
        _blueStep = (m_targetColor.b - _startColor.b) / _stepsCount;
    }

    private void OnDestroy()
    {
        _gameManager.OnReworked -= SwitchColor;
    }

    private void SwitchColor(int step)
    {
        _material.color = _startColor + new Color(_redStep * step, _greenStep * step, _blueStep * step);

        if (step == _stepsCount)
        {
            _gameManager.OnReworked -= SwitchColor;
        }
    }

}
