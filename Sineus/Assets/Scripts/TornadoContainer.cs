using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TornadoContainer : MonoBehaviour
{
    private List<Tornado> _tornados;

    private LevelController _levelController;
    private GameManager _gameManager;

    private int _trashesCount;
    private float _tornadosCountInStep;
    private int _removedTornadoCount;

    [Inject]
    public void Construct(LevelController levelController, GameManager gameManager)
    {
        _levelController = levelController;
        _gameManager = gameManager;
    }

    private void Start()
    {
        _trashesCount = _levelController.TrashWinCount;
        _gameManager.OnReworked += RemoveTornado;

        _tornados = new List<Tornado>();

        for (int i = 0; i < transform.childCount; i++)
        {
            _tornados.Add(transform.GetChild(i).GetComponent<Tornado>());
        }

        _tornadosCountInStep = (float)_trashesCount / _tornados.Count;

        Shuffle(_tornados);
    }

    private void OnDestroy()
    {
        _gameManager.OnReworked -= RemoveTornado;
    }

    private void Shuffle(List<Tornado> array)
    {
        var random = new System.Random();
        int n = array.Count;

        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Tornado value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }

    private void RemoveTornado(int step)
    {
        if (step / _tornadosCountInStep - _removedTornadoCount >= 1)
        {
            Destroy(_tornados[_removedTornadoCount].gameObject);

            _removedTornadoCount++;
        }

        if (step == _trashesCount)
        {
            DestroyRemainingTornados();
            _gameManager.OnReworked -= RemoveTornado;
        }
    }

    private void DestroyRemainingTornados()
    {
        foreach (var tornado in _tornados)
        {
            if (tornado != null)
            {
                Destroy(tornado.gameObject);
            }
        }
    }
}
