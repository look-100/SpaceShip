using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    public float flashDeltaTime;
    Material mat;
    Color originalColor;
    Color alphaColor = new Color(1, 1, 1, 0);

    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        originalColor = mat.color;
        StartCoroutine(BarrierFlash());
    }

    public IEnumerator BarrierFlash()
    {
        mat.color = alphaColor;
        yield return new WaitForSeconds(flashDeltaTime);
        mat.color = originalColor;

    }

    public void StopFlash()
    {
        StopCoroutine(BarrierFlash());
    }

}
