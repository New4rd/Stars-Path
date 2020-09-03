using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinGenerator : MonoBehaviour
{
    public GameObject starPrefab;
    public float spinRadius;
    public int length;
    public float zAxisStep;
    public float noiseScale;

    private float zAxis = 0;
    private float triAngle = 0;

    void Start()
    {
        for (int i = 0; i < length; i++)
        {
            Vector3 starPos = new Vector3(
                spinRadius * Mathf.Cos(triAngle) + Random.Range(-noiseScale, noiseScale),
                spinRadius * Mathf.Sin(triAngle) + Random.Range(-noiseScale, noiseScale),
                zAxis);
            Instantiate(starPrefab, starPos, Quaternion.identity);

            zAxis++;
            triAngle += Mathf.PI / 6;
        }
    }
}
