using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_4 : Cube {

    public GameObject cube_4_effect;

    private float touchTime = 0.0f;

    private Ray2D ray;
    private RaycastHit2D hit;

    public override IEnumerator DestroyEvent()
    {
        while (Input.GetMouseButton(0))
        {
            ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject != this.gameObject) break;

                touchTime += Time.deltaTime;
                if (touchTime >= 1.0f)
                {
                    Instantiate(cube_4_effect, transform.position, Quaternion.identity);
                    GameManager.Instance.blocks.Remove(this.gameObject);
                    Destroy(this.gameObject);
                    break;
                }
            }
            yield return null;
        }
    }

    public override void PointerDown()
    {
        StartCoroutine(DestroyEvent());
    }
    public override void PointerUp()
    {
        touchTime = 0;
    }
}
