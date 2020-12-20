using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeModel : MonoBehaviour
{
    private MeshFilter meshFilter;
    public GameObject someMesh;   //被替换的模型
    public Mesh alternateMesh;       //可选的替换模型
    void Start()
    {
        meshFilter = someMesh.GetComponent<MeshFilter>();
        meshFilter.mesh = alternateMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
