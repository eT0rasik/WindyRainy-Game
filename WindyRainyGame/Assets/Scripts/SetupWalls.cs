using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupWalls : MonoBehaviour
{
    enum TypeObject
    {
        WALLVERTICAL = 1,
        WALLDIAGONAL = 2,

        CLOUDMULTIPLY = 3,
        CLOUDMINUS = 4,
        CLOUDRANDOM = 5
    }

    [SerializeField] private Transform wallLeft;
    [SerializeField] private Transform wallRight;

    //Стены
    [SerializeField] private Object wallVertical;
    [SerializeField] private Object wallDiagonal;

    //Облака
    [SerializeField] private Object cloudMultiply;
    [SerializeField] private Object cloudMinus;
    [SerializeField] private Object cloudRandom;

    private List<Object> pointers = new List<Object>(25);
    private TypeObject[,] grid = new TypeObject[5, 5];
    private float[] X = { -3.75f, -1.875f, 0.0f, 1.875f, 3.75f };
    private float[] Y = { -3.8f, -1.9f, 0.0f, 1.9f, 3.8f };
    private float countDiagonal = 0;

    private void SpawnObject(float x, float y, TypeObject type)
    {
        Vector3 pos = new Vector3(x, y, -1);
        Quaternion rot = new Quaternion(0, 0, 0, 0);
        Object ptr = new Object();
        switch (type)
        {

            case TypeObject.WALLVERTICAL:
                ptr = Instantiate(wallVertical, pos, rot);
                break;
            case TypeObject.WALLDIAGONAL:
                if (countDiagonal > 2) return;
                rot.eulerAngles = new Vector3(0f, 0f, 45f);
                pos.x = (x > 0f) ? (x - 0.9375f) : (x + 0.9375f);
                ptr = Instantiate(wallDiagonal, pos, rot);
                countDiagonal++;
                break;
            case TypeObject.CLOUDMINUS:
                ptr = Instantiate(cloudMinus, pos, rot);
                break;
            case TypeObject.CLOUDMULTIPLY:
                ptr = Instantiate(cloudMultiply, pos, rot);
                break;
            case TypeObject.CLOUDRANDOM:
                ptr = Instantiate(cloudRandom, pos, rot);
                break;
            default: break;
        }

        if (ptr != null) pointers.Add(ptr);

    }
    private void ResetLevel()
    {
        foreach (var item in pointers)
        {
            Destroy(item);
        }

    }

    void SpawnWalls()
    {
        for (int j = 0; j < 5; j++)
        {
            TypeObject typeWall = (TypeObject)Random.Range(1, 3);
            var isSpawned = Random.Range(1, 11);
            if (isSpawned < 4)
            {
                
                SpawnObject(X[0], Y[j], typeWall);
                grid[0, j] = typeWall;
                

            }
        }
        for (int j = 0; j < 5; j++)
        {
            TypeObject typeWall = (TypeObject)Random.Range(1, 3);
            var isSpawned = Random.Range(1, 11);
            if (isSpawned < 4)
            {
                SpawnObject(X[4], Y[j], typeWall);
                grid[4, j] = typeWall;

            }
        }

        for (int j = 0; j < 5; j++)
        {
            for (int i = 1; i < 4; i++)
            {
                TypeObject typeWall = (TypeObject)Random.Range(1, 3);
                var isSpawned = Random.Range(1, 11);
                if (isSpawned < 9)
                {

                    if (typeWall == TypeObject.WALLDIAGONAL)
                    {
                        if (grid[i + 1, j] == TypeObject.WALLVERTICAL || grid[i - 1, j] == TypeObject.WALLVERTICAL )
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (grid[i + 1, j] == TypeObject.WALLDIAGONAL || grid[i - 1, j] == TypeObject.WALLDIAGONAL)
                        {
                            continue;
                        }
                    }
                  
                    SpawnObject(X[i], Y[j], typeWall);
                    grid[i, j] = typeWall;
                }
            }
        }
    }

        

         void Start()
        {

           //SpawnWalls();


        }

        // Update is called once per frame
        void Update()
        {


            float screenAspect = (float)Screen.width / Screen.height;
            float camHalfHeight = Camera.main.orthographicSize;
            float camHalfWidth = screenAspect * camHalfHeight;
            // Debug.Log(screenAspect);
            float camWidth = 2.0f * camHalfWidth;

            wallLeft.position = new Vector3(-camHalfWidth, wallLeft.position.y, wallLeft.position.z);
            wallRight.position = new Vector3(camHalfWidth, wallRight.position.y, wallRight.position.z);



        }
    
}
