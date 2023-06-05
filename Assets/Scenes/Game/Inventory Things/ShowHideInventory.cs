using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowHideInventory : MonoBehaviour
{
    [SerializeField] bool isShowing = true;
    //[SerializeField] GameObject inventory;
    //[SerializeField] bool isHiding = false;
    [SerializeField] TMP_Text show;
    [SerializeField] TMP_Text hide;
    [SerializeField] Vector2 showPosition;
    [SerializeField] Vector2 hidePosition;

    float startVal = 0f;
    float endVal = 10f;

    IEnumerator LerpPosition(Vector2 targetPosition, float duration)
    {
        float time = 0;
        Vector2 startPosition = transform.position;
        //print("start pos: " + startPosition + " end pos: " + targetPosition);
        while (time < duration)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    public void Start() {
        if(isShowing) show.enabled = false;
        //print(transform.position);
    }

    public void Move() {
        if(isShowing) MoveDown();
        else MoveUp();
    }

    public void MoveUp() {
        StartCoroutine(LerpPosition(showPosition, 0.5f));
        isShowing = true;
        show.enabled = false;
        hide.enabled = true;
    }

    public void MoveDown() {
        StartCoroutine(LerpPosition(hidePosition, 0.5f));
        isShowing = false;
        hide.enabled = false;
        show.enabled = true;
    }
}
