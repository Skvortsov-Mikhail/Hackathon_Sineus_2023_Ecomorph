using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildingsController : MonoBehaviour
{
    [SerializeField] private List<NewBuilding> m_newBuildingsPrefabs;

    private List<OldBuilding> _oldBuildings;

    private LevelController _levelController;
    private GameManager _gameManager;
    private IEntityFactory _factory;

    private Transform _parentTransform;

    private int _stepsCount;
    private int _buildingsCountInStep;

    [Inject]
    public void Construct(LevelController levelController, GameManager gameManager, IEntityFactory entityFactory)
    {
        _levelController = levelController;
        _gameManager = gameManager;
        _factory = entityFactory;
    }

    private void Start()
    {
        _parentTransform = transform;
        _stepsCount = _levelController.TrashWinCount;
        _gameManager.OnReworked += ChangeBuildings;


        _oldBuildings = new List<OldBuilding>();

        for (int i = 0; i < transform.childCount; i++)
        {
            _oldBuildings.Add(transform.GetChild(i).GetComponent<OldBuilding>());
        }

        _buildingsCountInStep = _oldBuildings.Count / _stepsCount;

        Shuffle(_oldBuildings);
    }

    private void OnDestroy()
    {
        _gameManager.OnReworked -= ChangeBuildings;
    }

    private void Shuffle(List<OldBuilding> array)
    {
        var random = new System.Random();
        int n = array.Count;

        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            OldBuilding value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }

    private void ChangeBuildings(OldBuilding oldBuilding)
    {
        var rnd = Random.Range(0, m_newBuildingsPrefabs.Count);

        var newBuilding = _factory.Create(m_newBuildingsPrefabs[rnd].gameObject, oldBuilding.transform.position, oldBuilding.transform.rotation, _parentTransform);

        Destroy(oldBuilding.gameObject);
    }

    private void ChangeBuildings(int step)
    {
        for (int i = (step - 1) * _buildingsCountInStep; i < step * _buildingsCountInStep; i++)
        {
            ChangeBuildings(_oldBuildings[i]);
        }

        if (step == _stepsCount)
        {
            ChangeRemainingBuildings();
            _gameManager.OnReworked -= ChangeBuildings;
        }
    }

    private void ChangeRemainingBuildings()
    {
        foreach (var building in _oldBuildings)
        {
            if (building != null)
            {
                ChangeBuildings(building);
            }
        }
    }
}
