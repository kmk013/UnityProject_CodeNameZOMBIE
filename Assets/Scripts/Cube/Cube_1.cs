using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_1 : Cube
{
    public GameObject cube_1_effect;

    public override IEnumerator DestroyEvent(){ yield return null; }

    public override void PointerDown()
    {
        GameManager.Instance.rayObject = this.gameObject;
    }

    public override void PointerUp()
    {
        Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
            if (GameManager.Instance.rayObject.name.Equals(hit.collider.name))
            {
                Instantiate(cube_1_effect, transform.position, Quaternion.identity);
                GameManager.Instance.blocks.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
    }
}