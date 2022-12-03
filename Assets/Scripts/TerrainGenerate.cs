using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerate : MonoBehaviour
{
    public bool autoUpdate;
    public bool randomiseHeight;
    public bool randomizeColor;
    public Transform targetTran;

    public Texture2D perlin;
    public bool usePerlin;

    public GameObject cube;

    public int row;
    public int col;
    public int offset;

    public Color BottomC;
    public Color TopC;
    public float randomZ;

    public float randomHeight;

    public Vector3 scale;
    public float cliffiness = 0.4f;
    public GameObject[] decors;
    [Range(0.0f, 1f)]
    public float decorChance;

    void Start()
    {
        Generate();

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            ResetCube();
        }
    }

    public void Generate()
    {
        if (randomizeColor)
        {
            BottomC = UnityEngine.Random.ColorHSV();
            TopC = UnityEngine.Random.ColorHSV();
        }
        if (randomiseHeight) {
            randomHeight = Random.Range(30f, 277f);
        }


        transform.position = new Vector3(0,0,0);
        transform.rotation = Quaternion.Euler(0,0,0);

        float perlinStart = Random.Range(0f, 10f); // randomise start point 
        //so it doesn't keep same every time

        for (int x = 0; x < row; x++)
        {

            for (int y = 0; y < col; y++)
            {

                var e = Instantiate(cube, this.transform);
                e.transform.localScale = scale;
                // setting color
                e.GetComponent<Renderer>().material.color =
                    ((float)y / (col - 1)) * TopC + (float)(1.0 - (y / (float)(col - 1))) * BottomC;

                if (usePerlin)
                {
                    e.transform.position = transform.position + new Vector3(x * offset, y * offset, 0);
                    e.transform.localScale += new Vector3(0, 0, 
                        Mathf.PerlinNoise((perlinStart+(float)x/ (float)row)/cliffiness, (perlinStart+((float)y / (float)col))/cliffiness) * randomHeight);
                }
                else
                {
                    e.transform.position = transform.position + new Vector3(x * offset, y * offset, Random.Range(-randomZ, randomZ));
                    e.transform.localScale += new Vector3(0, 0, Random.Range(5, randomHeight));
                }

                if (decorChance != 0 && decors != null) {
                    if (Random.Range(0, 1.0f) <= decorChance) {
                        int nDecors = decors.Length;
                        var d = Instantiate(decors[(int)Random.Range(0,nDecors)], e.transform.position, Quaternion.identity, transform);
                        d.transform.Rotate(-90, 0, 0);
                        d.transform.position += new Vector3(0, 0, -e.transform.localScale.z/2.0f);
                        d.transform.localScale *= e.transform.localScale.x/2;
                        d.GetComponent<Renderer>().material.color = e.GetComponent<Renderer>().material.color;
                    }
                }

                

            }


        }


        transform.position = targetTran.transform.position;
        transform.rotation = targetTran.transform.rotation;
    }

    public void ResetCube()
    {
        
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        Generate();
    }

}
