using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingleTon<GameManager>{

    [HideInInspector]
    public RaycastHit2D hit;
    [HideInInspector]
    public GameObject rayObject;

    private Ray2D ray;
    private Vector3 mousePos;

    private float touchTime;

    public float shakeTimer;
    private float shakeAmount = 0.1f;

    public List<GameObject> blocks = new List<GameObject>();

    private void Update()
    {
        InputTouch();

        if (Input.GetKeyDown(KeyCode.A))
            StartCoroutine(CameraShake());
            
    }

    //터치 입력
    private void InputTouch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
                hit.collider.GetComponent<Cube>().PointerDown();
        }

        if (Input.GetMouseButtonUp(0))
            if (rayObject != null)
                rayObject.GetComponent<Cube>().PointerUp();
    }

    public IEnumerator CameraShake()
    {
        float del = 0.0f;
        while(del <= shakeTimer)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            Camera.main.transform.position += new Vector3(ShakePos.x, ShakePos.y, 0);

            del += Time.deltaTime;
            yield return null;
        }

        Camera.main.transform.position = new Vector3(0, 0, -10);
    }
}
