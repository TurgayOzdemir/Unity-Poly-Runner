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

    private void Start()
    {
        StartCoroutine(upDown());
    }
}
