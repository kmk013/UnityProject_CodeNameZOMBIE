using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_2 : Cube
{
    public GameObject cube_2_particle;

    public Sprite normal;
    public List<Sprite> divide = new List<Sprite>();

    private Vector3 mousePos;
    private int divideNum = 0;

    public override IEnumerator DestroyEvent(){ yield return null; }
    public IEnumerator DragEvent()
    {
        while (Input.GetMouseButton(0))
        {
            float dis = Vector3.Distance(Input.mousePosition, mousePos);
            if(dis >= (100.0f / (divide.Count + 1)) * (divideNum + 1))
            {
                if(divideNum >= divide.Count)
                {
                    Instantiate(cube_2_particle, transform.position, Quaternion.identity);
                    GameManager.Instance.blocks.Remove(this.gameObject);
                    Destroy(this.gameObject);
                    break;
                }
                else
                    GetComponent<SpriteRenderer>().sprite = divide[divideNum];
                divideNum++;
            }
            yield return null;
        }
    }

    public override void PointerDown()
    {
        GameManager.Instance.rayObject = this.gameObject;
        mousePos = Input.mousePosition;
        StartCoroutine(DragEvent());
    }

    public override void PointerUp()
    {
        GetComponent<SpriteRenderer>().sprite = normal;
        divideNum = 0;
        GameManager.Instance.rayObject = null;
    }
}
