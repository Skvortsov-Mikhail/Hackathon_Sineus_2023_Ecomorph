using UnityEngine;

public interface IEntityFactory
{
    public GameObject Create(GameObject prefabe, Vector3 position, Quaternion rotation, Transform parent);
}
