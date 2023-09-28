using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum ItemType
{
    Plastic,
    Paper,
    Glass,
    Metall
}

public class Trash : MonoBehaviour
{
    [SerializeField] private List<TrashVisualModel> m_trashVisualModels;

    [SerializeField] private List<Organic> m_organicPrefab;

    [SerializeField] private Transform m_parentTransform;

    private SphereCollider _sphereCollider;

    private IEntityFactory _factory;

    private GameManager _gameManager;

    private ItemType _type;
    public ItemType Type => _type;

    [Inject]
    public void Construct(IEntityFactory entityFactory, GameManager gameManager)
    {
        _factory = entityFactory;

        _gameManager = gameManager;
    }

    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();

        var rnd = Random.Range(0, m_trashVisualModels.Count);

        _factory.Create(m_trashVisualModels[rnd].gameObject, transform.position, Quaternion.identity, m_parentTransform);

        _type = m_trashVisualModels[rnd].Type;
    }

    private void OnTriggerEnter(Collider other)
    {
        var character = other.transform.root.GetComponent<CharacterMovement>();

        if (character != null)
        {
            _sphereCollider.enabled = false;

            _gameManager.ReworkedTrash();

            foreach (var organic in m_organicPrefab)
            {
                if (_type == organic.Type)
                {
                    _factory.Create(organic.gameObject, transform.position, Quaternion.identity, null);

                    break;
                }
            }

            Destroy(gameObject);
        }
    }
}
