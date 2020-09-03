using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsGenerator : MonoBehaviour
{
    /// <summary>
    /// Le prefab pour l'étoile
    /// </summary>
    public GameObject starPrefab;

    /// <summary>
    /// La limite extérieure pour la génération d'étoiles (boîte cubique)
    /// </summary>
    public Vector2 maxGenerationLimit;

    /// <summary>
    /// La limite intérieure pour la génération d'étoiles (boîte cubique)
    /// </summary>
    public Vector2 minGenerationLimit;

    /// <summary>
    /// Le nombre d'étoiles pouvant être générées par bloc
    /// </summary>
    public int starAmountBlock;

    /// <summary>
    /// La longueur d'un bloc, selon l'axe Z
    /// </summary>
    private float blockSize = 100f;

    /// <summary>
    /// Liste des blocs d'étoiles
    /// </summary>
    private List<List<GameObject>> StarBlocksList;

    private int blockIteration = 0;

    private void Start()
    {
        StarBlocksList = new List<List<GameObject>>();
        FirstGeneration();
    }


    private void Update()
    {
        Debug.Log(StarBlocksList.Count);
        if (AutomoveCamera.Inst.transform.position.z % 100 < 0.15)
        {
            blockIteration++;
            BlockStarGeneration(blockIteration * blockSize);
            RemoveBlockStar();
        }

    }

    private void FirstGeneration ()
    {
        BlockStarGeneration(0);
        BlockStarGeneration(100);
    }


    public void BlockStarGeneration (float zPosition)
    {
        List<GameObject> starList = new List<GameObject>();
        int counter = 0;

        while (counter != starAmountBlock)
        {
            float xRandom = Random.Range(-maxGenerationLimit.x, maxGenerationLimit.x);
            float yRandom = Random.Range(-maxGenerationLimit.y, maxGenerationLimit.y);

            if (Mathf.Abs(xRandom) < Mathf.Abs(minGenerationLimit.x)
                && Mathf.Abs(yRandom) < Mathf.Abs(minGenerationLimit.y))
                continue;

            Vector3 starPos = new Vector3(xRandom, yRandom, Random.Range(zPosition, zPosition+blockSize));
            GameObject instStar = Instantiate(starPrefab, starPos, Quaternion.identity);
            starList.Add (instStar);
            counter++;
        }
        StarBlocksList.Add(starList);
    }


    public void RemoveBlockStar ()
    {
        foreach (GameObject obj in StarBlocksList[0])
        {
            Destroy(obj);
        }
        StarBlocksList.RemoveAt(0);
    }
}
