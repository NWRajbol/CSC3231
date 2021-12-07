using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrowVineSript : MonoBehaviour
{
    public List<MeshRenderer> growVineMesh;
    public float growTime = 20;
    public float refreshRate = 0.05f;
    [Range(0,1)]
    public float minGrow = 0.2f;
    [Range(0, 1)]
    public float maxGrow = 9.97f;

    private List<Material> growVinesMat = new List<Material>();
    private bool fullGrow;



    // Start is called before the first frame update
    void Start()
    {
     
        for (int i = 0; i<growVineMesh.Count; i++)
        {
            for(int j=0;  j <growVineMesh[i].materials.Length; j++)
            {
                if (growVineMesh[i].materials[j].HasProperty("_Grow"))
                {
                    growVineMesh[i].materials[j].SetFloat("_Grow", minGrow);
                    growVinesMat.Add(growVineMesh[i].materials[j]);
                }
            }
        }

        for (int i = 0; i < growVinesMat.Count; i++)
        {
            StartCoroutine(GrowVines(growVinesMat[i]));
        }




    }

    // Update is called once per frame
    void Update()
    {
    
          
   
    }


    IEnumerator GrowVines(Material mat)
    {
        float growValue = mat.GetFloat("_Grow");
        if (!fullGrow)
        {
            while (growValue < maxGrow)
            {
                growValue += 1 / (growTime / refreshRate);
                mat.SetFloat("_Grow", growValue);
                yield return new WaitForSeconds(refreshRate);
            }
        }
        else
        {
            while (growValue < minGrow)
            {
                growValue -= 1 / (growTime / refreshRate);
                mat.SetFloat("_Grow", growValue);

                yield return new WaitForSeconds(refreshRate);

            }
        }

        if (growValue >= maxGrow)
        {
            fullGrow = true;
        }
        else
        {
            fullGrow = false;
        }
       }

       

}
