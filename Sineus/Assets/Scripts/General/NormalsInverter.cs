using UnityEngine;

public class NormalsInverter : MonoBehaviour
{
    public GameObject InvertedObject;

    private void Start()
    {
        InvertMesh();
    }

    private void InvertMesh()
    {
        Vector3[] normals = InvertedObject.GetComponent<MeshCollider>().sharedMesh.normals;

        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }

        InvertedObject.GetComponent<MeshCollider>().sharedMesh.normals = normals;

        int[] triangles = InvertedObject.GetComponent<MeshCollider>().sharedMesh.triangles;

        for (int i = 0; i < triangles.Length; i += 3)
        {
            int t = triangles[i];
            triangles[i] = triangles[i + 2];
            triangles[i + 2] = t;
        }

        InvertedObject.GetComponent<MeshCollider>().sharedMesh.triangles = triangles;
    }
}
