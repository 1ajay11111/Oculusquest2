using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeScript : MonoBehaviour
{
    MeshRenderer meshrender;
    Material m_Material;
    public Material[] oldmaterial;
    public GameObject[] objectMaterial;
    public GameObject[] textobject;
    //public Material Deaerator_Material,Heat_Material;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
       // ButtonClicked(3);
    }
   
    public void ButtonClicked(int index)
    {
        for(int i = 0; i < objectMaterial.Length; i++)
        {
            if (index != i)
            {
                ApplyMaterialToChild(objectMaterial[i],oldmaterial[i]);
                textobject[i].SetActive(false);
            }
            else
            {
                ApplyMaterialToColorChild(objectMaterial[i]);
                textobject[i].SetActive(true);
            }
        }
    }
    public void ApplyMaterialToColorChild(GameObject gameObject)
    {
        if (gameObject.GetComponent<MeshRenderer>() == null)
        {
            gameObject.AddComponent<UnityEngine.MeshRenderer>();
        }
        gameObject.GetComponent<Renderer>().material.color = Color.red; ;
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.GetComponent<MeshRenderer>() == null)
            {
                child.gameObject.AddComponent<UnityEngine.MeshRenderer>();
            }

            child.gameObject.GetComponent<Renderer>().material.color = Color.red; ;
            ApplyMaterialToColorChild(child.gameObject);

        }
    }
    public void ApplyMaterialToChild(GameObject gameObject, Material materialData)
    {
        if (gameObject.GetComponent<MeshRenderer>() == null)
        {
            gameObject.AddComponent<UnityEngine.MeshRenderer>();
        }
        gameObject.GetComponentInChildren<Renderer>().material = materialData;
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.GetComponent<MeshRenderer>() == null)
            {
                child.gameObject.AddComponent<UnityEngine.MeshRenderer>();
            }
            child.gameObject.GetComponent<Renderer>().material = materialData;
                    ApplyMaterialToChild(child.gameObject,materialData);

        }
    }
    public void Deaerator()
    {
        m_Material.color = Color.red;

    }
    public void Heater(int index)
    {
        m_Material.color = Color.green;

       
    }
}
