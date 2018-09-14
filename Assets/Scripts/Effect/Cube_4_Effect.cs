using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_4_Effect : MonoBehaviour {

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            Destroy(this.gameObject);
    }
}
