using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public Vector3[] pOIs; // 2, 3, 4
    public Transform[] vertices; // 2*pOIs, 2*pOIs, 2*pOIs
    public Vector3[] vertexVectors;
    int[] tris; // (pOIs * (pOIs * 2 - 2)) = 6, 12, 24

    public float width = 1;
    public float height = 1;

    public void Start()
    {
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        /*Vector3[] vertices = new Vector3[4] //  2*2
        {
            new Vector3(0, 0, 0), // 0
            new Vector3(width, 0, 0), // 1
            new Vector3(0, 0, height),  // 2
            new Vector3(width, 0, height) // 3
        };*/
        vertexVectors = new Vector3[pOIs.Length * (pOIs.Length + 1)];
        for (int i = 0; i < vertices.Length; ++i)
        {
            vertexVectors[i] = vertices[i].position;
        }
        mesh.vertices = vertexVectors;

        /*int[] tris = new int[6] // 2*3
        {
            // lower left triangle
            0, 2, 1,
            // upper right triangle
            2, 3, 1
        };*/
        /*int[] tris = new int[12]
        {
             0, 1, 2,
             2, 3, 4,
             4, 3, 5,
             2, 1, 3
        };*/
        tris = new int[(pOIs.Length) * (pOIs.Length * 2 - 2)]; // 12개 0, 1, 2, 3, 4, 5
        for (int i = 0; i < tris.Length * 0.5 - 1; ++i) // 
        {
            
            //     0, 1, 2,
            //     2, 3, 4
        }

        for (int i = tris.Length; i > 0; --i) // 6, 7, 8, 9, 10, 11
        {
            //     4, 3, 5,
            //     2, 1, 3
        }

        mesh.triangles = tris;

        Vector3[] normals = new Vector3[vertices.Length];
        for(int i = 0; i < normals.Length; ++i)
        {
            normals[i] = -Vector3.forward;
        }
        mesh.normals = normals;

        /*Vector2[] uv = new Vector2[6];
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(2, 0),
            new Vector2(2, 1)
        };*/
        Vector2[] uv = new Vector2[vertices.Length];
        for (int i = 0; i < uv.Length; ++i)
        {
            uv[i] = -Vector3.forward;
        }
        mesh.uv = uv;

        meshFilter.mesh = mesh;
    }
}
