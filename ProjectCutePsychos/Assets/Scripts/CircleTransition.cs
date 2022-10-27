using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CircleTransition : MonoBehaviour
{
    [SerializeField] Material _transitionMat;
    [SerializeField] float transitionTime = 1.0f;
    [SerializeField] string propertyName = "_Progress";
    public UnityEvent OnTransitionDone;
    private void Start() {
        StartCoroutine(DoTransition());
    }
    IEnumerator DoTransition(){
        float currentTime = 0;
        while (currentTime < transitionTime){
            currentTime += Time.deltaTime;
            _transitionMat.SetFloat(propertyName, Mathf.Clamp01(currentTime/transitionTime));
            yield return null;
        }
        OnTransitionDone?.Invoke();
    }
}