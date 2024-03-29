using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hiding : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer[] meshes;
    [SerializeField]
    private Material[] material = new Material[3];
    [SerializeField]
    private Material transparent;
    [SerializeField]
    private Canvas canvas;
    private BasePooling @base;
    private Coroutine getpos;
    private List<Vector3> posA = new List<Vector3>();
    private List<Vector3> posB = new List<Vector3>();

    private void Start()
    {
        for(int i = 0; i < meshes.Length; i++)
        {
            material[i] = meshes[i].material;
        }
        @base = FindObjectOfType<BasePooling>();
        canvas = GetComponentInChildren<Canvas>();
        if (SceneManager.GetActiveScene().name == "Base2an")
        {
            if (getpos != null)
            {
                StopCoroutine(getpos);
                getpos = StartCoroutine(getUpdate());
            }
        }
    }

   IEnumerator getUpdate()
    {
        while (true)
        {
            GetPos(posA, "Seek");
            GetPos(posB, "Hide");

            yield return null;
        }
        
    }

    public void Hunted(Material mat)
    {
        for(int i = 0; i < meshes.Length; i++)
        {
            if(meshes[i] != meshes[1])
            {
                meshes[i].material = mat;
            }
        }
    }

    private void GetPos(List<Vector3> vectors, string name)
    {
        for (int i = 0; i < 3; i++)
        {
            Vector3 vector = @base.GetPoolPos(name);
            vectors.Add(vector);
        }
    }

    private void MovePos(List<Vector3> vectors)
    {
        for(int i = 0; i < vectors.Count; i++)
        {
            if(transform.position != vectors[i])
            {
                transform.position = vectors[i];
            }
        }
    }

    public void hiding(string tag)
    {
        foreach(var mesh in meshes)
        {
            mesh.material = transparent;
        }
        MoveToPos(tag);
    }

    public void notHiding()
    {
        for(int i = 0; i < material.Length; i++)
        {
            meshes[i].material = material[i];
        }
    }

    public void MoveToPos(string tag)
    {
        switch (tag)
        {
            case "Hide":
                MovePos(posB);
                break;
            case "Seek":
                MovePos(posA);
                break;
        }
    }
}
