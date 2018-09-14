using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cube : MonoBehaviour {

    public abstract void PointerDown();
    public abstract void PointerUp();
    public abstract IEnumerator DestroyEvent();

    [Range(1f, 2.5f)]
    public float initEffectSpeed;

    private void Start()
    {
        transform.localScale = Vector3.zero;

        StartCoroutine(InitEffect());
    }

    private IEnumerator InitEffect() {
        while(transform.localScale.x < 0.925f) {
            transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime) * initEffectSpeed;
            yield return null;
        }
    }
}
