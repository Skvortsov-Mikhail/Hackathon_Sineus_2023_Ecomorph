using UnityEngine;
using Zenject;

public class EntityFactory : IEntityFactory
{
    private DiContainer _diContainer;

    [Inject]
    public void Construct(DiContainer diContainer)
    {
        _diContainer = diContainer;
    }

    public GameObject Create(GameObject prefabe, Vector3 position, Quaternion rotation, Transform parent)
    {
        return _diContainer.InstantiatePrefab(prefabe, position, rotation, parent);
    }
}
