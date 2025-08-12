using System;
using Farm;
using Mono.Cecil;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public enum FieldState { Seed, Harvest }
    private FieldState fieldState;
    
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject plantPrefab;
    [SerializeField] private Vector2 fieldSize = new Vector2(10, 10);
    [SerializeField] private float tileSize = 2f;
    [SerializeField] private LayerMask fieldLayer;

    private GameObject[,] tileArray;
    private Camera mainCamera;

    private Transform tileRoot;
    private Transform plantRoot;
    private Transform cropRoot;

    private void Awake()
    {
        tileRoot = new GameObject("Tiles").transform;
        tileRoot.SetParent(transform);
        plantRoot = new GameObject("Plants").transform;
        plantRoot.SetParent(transform);
        cropRoot = new GameObject("Crops").transform;
        cropRoot.SetParent(transform);
        
        mainCamera = Camera.main;
        tileArray = new GameObject[(int)fieldSize.x, (int)fieldSize.y];
        
        CreateField();
    }

    private void Update()
    {
        if (Farm.GameManager.Instance.cameraState == CameraState.Field)
        {
            switch (fieldState)
            {
                case FieldState.Seed:
                    OnSeed();
                    break;
                case FieldState.Harvest:
                    OnHarvest();
                    break;
            }
        }
    }

    void CreateField()
    {
        float offsetX = (fieldSize.x - 1) * tileSize / 2;
        float offsetY = (fieldSize.y - 1) + tileSize / 2;

        for (int i = 0; i < fieldSize.x; i++)
        {
            for (int j = 0; j < fieldSize.y; j++)
            {
                float posX = transform.position.x + i * tileSize - offsetX;
                float posZ = transform.position.z + j * tileSize - offsetY;

                GameObject tileObj = Instantiate(tilePrefab, tileRoot);
                tileObj.name = $"Tile_{i}_{j}";
                tileObj.transform.position = new Vector3(posX, 0, posZ);
                // tileArray[i, j] = tileObj;
                tileObj.GetComponent<Tile>().arrayPos = new Vector2Int(i, j);
            }
        }
    }

    void OnSeed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, fieldLayer))
            {
                Tile tile = hit.collider.gameObject.GetComponent<Tile>();

                if (tileArray[tile.arrayPos.x, tile.arrayPos.y] != null)
                    return;
                
                GameObject plant = Instantiate(plantPrefab, plantRoot);
                tileArray[tile.arrayPos.x, tile.arrayPos.y] = plant;
                plant.transform.position = tile.gameObject.transform.position;
            }
        }
    }

    void OnHarvest()
    {
        
    }
}
