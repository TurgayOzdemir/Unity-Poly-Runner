using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemAnimationController : MonoBehaviour
{
    private IEnumerator upDown()
    {
        while (true){
        transform.DOMoveY(transform.position.y + 1,1);
        yield return new WaitForSeconds(1);
        transform.DOMoveY(transform.position.y - 1,1);
        yield return new WaitForSeconds(1);
        }
    }

    private IEnumerator HazardSawVerticalMove()
    {
        while (true){
        transform.DOMoveZ(transform.position.z + 10, 1.25f);
        yield return new WaitForSeconds(1.25f);
        transform.DOMoveZ(transform.position.z - 10, 1.25f);
        yield return new WaitForSeconds(1.25f);
        }

    }

    private void Start()
    {
        if (gameObject.CompareTag("Coin"))
        {
            StartCoroutine(upDown());
        }
        if (gameObject.CompareTag("Saw"))
        {
            StartCoroutine(HazardSawVerticalMove());
        }
        
    }
}
