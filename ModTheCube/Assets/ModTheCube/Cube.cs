using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public Vector3 cubePosition = new Vector3(3, 4, 1);
    public Vector3 cubeScale = Vector3.one * 1.3f;
    public Vector3 cubeRotation = new Vector3(10.0f, 0.0f, 0.0f);
    public Color[] cubeColors = { new Color(0.5f, 1.0f, 0.3f, 0.4f), new Color(0.5f, 1.0f, 0.3f, 0.4f), new Color(0.5f, 1.0f, 0.3f, 0.4f) };

    [Header("If checked, need min and max")]
    public bool isRandomScale;
    public Vector3 cubeMinScale;
    public Vector3 cubeMaxScale;


    private float _time = 0;
    public int changeColorTime = 3;

    void Start()
    {
        transform.position = cubePosition;
        if(isRandomScale && cubeMinScale != Vector3.zero && cubeMaxScale != Vector3.zero)
        {
            float randomX = Random.Range(cubeMinScale.x, cubeMaxScale.x);
            float randomY = Random.Range(cubeMinScale.y, cubeMaxScale.y);
            float randomZ = Random.Range(cubeMinScale.z, cubeMaxScale.z);
            transform.localScale = new Vector3(randomX, randomY, randomZ);
        }
        else
            transform.localScale = cubeScale;
        
        Material material = Renderer.material;
        
        material.color = cubeColors[0];
    }
    
    void Update()
    {
        transform.Rotate(cubeRotation.x * Time.deltaTime, cubeRotation.y * Time.deltaTime, cubeRotation.z * Time.deltaTime);

        _time += Time.deltaTime;
        if (_time <= changeColorTime)
        {
            Material material = Renderer.material;
            if (material.color != cubeColors[0]) material.color = cubeColors[0];
        }
        else if (_time >= changeColorTime && _time <= changeColorTime * 2)
        {
            Material material = Renderer.material;
            if (material.color != cubeColors[1]) material.color = cubeColors[1];
        }
        else
        {
            
            Material material = Renderer.material;           
            if (material.color != cubeColors[2]) material.color = cubeColors[2];

            if(_time >= changeColorTime * 3)_time = 0;
        }
    }
}
