using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("Transfer");
    }

    IEnumerator Transfer()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Hit the trigger zone after one second");
        transform.parent.position = new Vector3(0.0f, 0.0f, transform.parent.position.z + 400);
    }
}
