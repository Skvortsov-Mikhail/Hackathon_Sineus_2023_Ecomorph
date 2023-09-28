using System.Collections.Generic;
using UnityEngine;

public class TrashContainer : MonoBehaviour
{
    private List<Trash> Trashes;

    private void Start()
    {
        Trashes = new List<Trash>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Trashes.Add(transform.GetChild(i).GetComponent<Trash>());
        }
    }

    public bool HasTrashNear(Transform playerPosition, float detectionDistance)
    {
        foreach (var trash in Trashes)
        {
            float dist = Mathf.Abs(Vector3.Distance(trash.transform.position, playerPosition.position));

            if (dist < detectionDistance) return true;
        }

        return false;
    }
}
