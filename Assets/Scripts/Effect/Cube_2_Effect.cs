using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_2_Effect : MonoBehaviour {
    
    private void Update()
    {
        if (!GetComponent<ParticleSystem>().isPlaying)
            Destroy(this.gameObject);
    }
}
