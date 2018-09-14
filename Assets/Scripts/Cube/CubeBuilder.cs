using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBuilder : SingleTon<CubeBuilder>
{
    public GameObject cube_2_2;
    public GameObject cube_1_2;
    public GameObject cube_1_1;
    public GameObject biteBlock;
    public GameObject needleBlock;

    [Space(15)]
    [Range(0, 8)]
    public int createCube22Cnt;
    [Range(0, 18)]
    public int createCube21Cnt;
    
    [HideInInspector] public bool[,] isCanCreate = new bool[4, 9];
    [HideInInspector] public List<float> createX = new List<float>() { -2.5f, -0.85f, 0.8f, 2.45f};
    [HideInInspector] public List<float> createY = new List<float>() { -4.4f, -2.75f, -1.1f, 0.55f, 2.2f, 3.85f, 5.5f, 7.15f, 8.8f};

    private void Start()
    {
        InitialBlockCreate();
    }

    private void InitialBlockCreate()
    {
        for (int i = 0; i < 9; i++)
            for (int j = 0; j < 4; j++)
                isCanCreate[j, i] = true;

        if (createCube22Cnt > 0)
            for (int i = 0; i < createCube22Cnt; i++)
            {
                int posX = Random.Range(0, createX.Count - 1), posY = Random.Range(0, createY.Count - 1);

                if (CanCreateBlock_4(posX, posY))
                    CreateCube_4(posX, posY);
            }
                

        
        if (createCube21Cnt > 0)
            for (int i = 0; i < createCube21Cnt; i++)
                if (CanCreateBlock50Percent())
                {
                    int posX = Random.Range(0, createX.Count - 1);
                    int posY = Random.Range(0, createY.Count);
		
                    if (CanCreateBlock_2(1, posX, posY))
                        CreateCube_2(1, posX, posY);
                }
                else
                {
                    int posX = Random.Range(0, createX.Count);
                    int posY = Random.Range(0, createY.Count - 1);
		
                    if (CanCreateBlock_2(0, posX, posY))
                        CreateCube_2(0, posX, posY);
                }

        for (int i = 0; i < createY.Count; i++)
            for (int j = 0; j < createX.Count; j++)
                if (isCanCreate[j, i]) CreateCube_1(j, i);
    }

    private bool CanCreateBlock50Percent()
    {
        if (Random.Range(0, 2) == 0)
            return true;
        else
            return false;
    }

    private bool CanCreateBlock_4(int posX, int posY)
    {
        for (int j = posY; j < posY + 2; j++)
            for (int k = posX; k < posX + 2; k++)
                if (!isCanCreate[k, j]) return false;
                else continue;

        return true;
    }
    private bool CanCreateBlock_2(int type, int posX, int posY)
    {
        if (type == 0)
        {
            for (int j = posY; j < posY + 2; j++)
                if (!isCanCreate[posX, j]) return false;
                else continue;
        }
        else if (type == 1) //2*1
        {
            for (int j = posX; j < posX + 2; j++)
                if (!isCanCreate[j, posY]) return false;
                else continue;
        }
        return true;
    }

    private void CreateCube_4(int posX, int posY)
    {
        float aveX = (createX[posX] + createX[posX + 1]) / 2;
        float aveY = (createY[posY] + createY[posY + 1]) / 2;
        GameManager.Instance.blocks.Add(
            Instantiate(
                cube_2_2,
                new Vector2(aveX, aveY),
                Quaternion.identity
            )
        );

        for (int j = posY; j < posY + 2; j++)
            for (int k = posX; k < posX + 2; k++)
                isCanCreate[k, j] = false;
    }
    private void CreateCube_2(int type, int posX, int posY)
    {
        if (type == 0) //1*2
        {
            float aveY = (createY[posY] + createY[posY + 1]) / 2;
            GameManager.Instance.blocks.Add(
                Instantiate(
                    cube_1_2,
                    new Vector2(createX[posX], aveY),
                    Quaternion.Euler(0, 0, Random.Range(0, 2) * 180)
                )
            );
            for (int j = posY; j < posY + 2; j++)
                isCanCreate[posX, j] = false;
        }
        else if (type == 1)
        {
            float aveX = (createX[posX] + createX[posX + 1]) / 2;
            GameManager.Instance.blocks.Add(
                Instantiate(
                    cube_1_2,
                    new Vector2(aveX, createY[posY]),
                    Quaternion.Euler(0, 0, 90 + Random.Range(0, 2) * 180)
                )
            );
            for (int j = posX; j < posX + 2; j++)
                isCanCreate[j, posY] = false;
        }
    }
    private void CreateCube_1(int posX, int posY)
    {
        GameManager.Instance.blocks.Add(
            Instantiate(cube_1_1, new Vector2(createX[posX], createY[posY]), Quaternion.identity)
        );
    }
}
