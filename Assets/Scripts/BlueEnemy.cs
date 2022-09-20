using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour
{
    public float sec = 4f;

    void Update()
    {
        StartCoroutine(SetInactive(sec));
    }

    IEnumerator SetInactive(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        gameObject.SetActive(false);
    }
}
