using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationController : MonoBehaviour {
    public int lGenLength = 16;
    public int rGenLength = 16;
    public GameObject grassBlock;
    public GameObject dirtBlock;
    public GameObject oakTree;
    public GameObject stoneBlock;
    public GameObject darkStoneBlock;
    private List<float> yValues = new List<float> { -0.86f, -0.7012f };
    private List<float> caveYValues = new List<float> { -2.296f, -2.454f, -2.615f, -2.776f, -2.937f };
    private List<float> treeX = new List<float> {};
    // private List<float> nzesfValues = new List<float> { -0.86f, -0.7012f };
    // private List<float> nzszotfValues = new List<float> { -0.86f, -0.7012f, -0.5412f };
    // private List<float> nzffotfValues = new List<float> { -0.7012f, -0.5412f, -0.3812f };
    // private List<float> nzteotfValues = new List<float> { -0.5412f, -0.3812f };
    

    void GenerateWorld() {
        for (int i = 0; i < rGenLength; i++) {
            float randomY = GetRandomY();
            // float Y;
            // if (randomY == -0.86f) {
            //     int randomIndex = Random.Range(0, nzesfValues.Count);
            //     Y = nzesfValues[randomIndex];
            // }
            // else if (randomY == -0.7012f) {
            //     int randomIndex = Random.Range(0, nzszotfValues.Count);
            //     Y = nzszotfValues[randomIndex];
            // }
            // else if (randomY == -0.5412f) {
            //     int randomIndex = Random.Range(0, nzffotfValues.Count);
            //     Y = nzffotfValues[randomIndex];
            // }
            // else if (randomY == -0.3812f) {
            //     int randomIndex = Random.Range(0, nzteotfValues.Count);
            //     Y = nzteotfValues[randomIndex];
            // }
            // else {
            //     Y = randomY;
            // }
            // float proceduralY = Y;
            Vector3 grassBlockPosition = new Vector3(i * 0.16f, randomY, 0);
            Instantiate(grassBlock, new Vector3(i * 0.16f, randomY, 0), Quaternion.identity);
            SpawnDirtBlocks(grassBlockPosition);
            SpawnOakTrees(grassBlockPosition);
            GenerateStone(grassBlockPosition);
            GenerateCaves(grassBlockPosition);
        }



        for (int c = 0; c < lGenLength; c++) {
            float randomY = GetRandomY();
            Vector3 grassBlockPosition = new Vector3(c * -0.16f, randomY, 0);
            Instantiate(grassBlock, new Vector3(c * -0.16f, randomY, 0), Quaternion.identity);
            SpawnDirtBlocks(grassBlockPosition);
            SpawnOakTrees(grassBlockPosition);
            GenerateStone(grassBlockPosition);
            GenerateCaves(grassBlockPosition);
        }
    }

    
    float GetRandomY() {
        int randomIndex = Random.Range(0, yValues.Count);
        return yValues[randomIndex];
    }
    void SpawnDirtBlocks(Vector3 grassBlockPosition) {
        for (int i = 1; i <= 4; i++) {
            Instantiate(dirtBlock, new Vector3(grassBlockPosition.x, grassBlockPosition.y - i * 0.16f, grassBlockPosition.z), Quaternion.identity);
        }
    }
    void SpawnOakTrees(Vector3 grassBlockPosition) {
        int num = Random.Range(1, 10);
        if (!treeX.Contains(grassBlockPosition.x)) {
            if (num == 5) {
                Instantiate(oakTree, new Vector3(grassBlockPosition.x, grassBlockPosition.y + 1 * 0.16f, grassBlockPosition.z), Quaternion.identity);
                treeX.Add(grassBlockPosition.x);
            }

        }//      Debug.Log(num);
    }


    void GenerateStone(Vector3 grassBlockPosition) {
        for (int i = 1; i <= 4; i++) {
            Instantiate(stoneBlock, new Vector3(grassBlockPosition.x, grassBlockPosition.y - 0.64f - i * 0.16f, grassBlockPosition.z), Quaternion.identity);
            Instantiate(stoneBlock, new Vector3(grassBlockPosition.x, -1.8212f, grassBlockPosition.z), Quaternion.identity);
            Instantiate(stoneBlock, new Vector3(grassBlockPosition.x, -1.98f, grassBlockPosition.z), Quaternion.identity);
            Instantiate(stoneBlock, new Vector3(grassBlockPosition.x, -2.14f, grassBlockPosition.z), Quaternion.identity);
        }
    }

    void GenerateCaves(Vector3 grassBlockPosition) {
        float randomCaveY() {
        int randomIndex = Random.Range(0, caveYValues.Count);
        return caveYValues[randomIndex];
        }

        float randomY = randomCaveY();
        Instantiate(stoneBlock, new Vector3(grassBlockPosition.x , randomY, 0), Quaternion.identity);
        Instantiate(darkStoneBlock, new Vector3(grassBlockPosition.x , -2.296f , 1), Quaternion.identity);
        Instantiate(darkStoneBlock, new Vector3(grassBlockPosition.x , -2.454f , 1), Quaternion.identity);
        Instantiate(darkStoneBlock, new Vector3(grassBlockPosition.x , -2.615f , 1), Quaternion.identity);
        Instantiate(darkStoneBlock, new Vector3(grassBlockPosition.x , -2.776f , 1), Quaternion.identity);
        Instantiate(darkStoneBlock, new Vector3(grassBlockPosition.x , -2.937f , 1), Quaternion.identity);
    }
    
    private void Start() {
        GenerateWorld();
        treeX.Clear();
    }

}