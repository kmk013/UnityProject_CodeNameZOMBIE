using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_1_Effect : MonoBehaviour {
    
    private void Update()
    {
        if (!GetComponent<ParticleSystem>().isPlaying)
            Destroy(this.gameObject);
    }
}
