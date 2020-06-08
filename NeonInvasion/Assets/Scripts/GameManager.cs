using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

    public float probeSpawnMin = 2.0f;

    public float probeSpawnMax = 8.0f;

    public float enemySpawnMin = 2.0f;

    public float enemySpawnMax = 8.0f;

    public float verticalWallSpawnMin = 10.0f;

    public float verticalWallSpawnMax = 20.0f;

    public float horizontalWallSpawnMin = 10.0f;

    public float horizontalWallSpawnMax = 20.0f;

    public float powerUpSpawnMin = 20.0f;

    public float powerUpSpawnMax = 30.0f;

    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private Transform spawnPoint;

    private bool endPoint = false;
    
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        endPoint = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (uiManager.score >= 25)
        {
            AddDifficultyOne();            
        }        

        if (uiManager.score >= 50)
        {
            AddDifficultyTwo();            
        }

        if (uiManager.score >= 75)
        {
            AddDifficultyThree();
        }

        if (uiManager.score >= 100)
        {
            AddDifficultyFour();
        }

        if (uiManager.score >= 125)
        {
            AddDifficultyFive();
        }

        if (uiManager.score >= 150)
        {
            AddDifficultySix();
        }

        if (uiManager.score >= 175)
        {
            AddDifficultySeven();
        }

        if (uiManager.score >= 200)
        {
            AddDifficultyEight();
        }

        if (uiManager.score >= 225)
        {
            AddDifficultyNine();
        }

        if (uiManager.score >= 250)
        {
            AddDifficultyTen();
        }

        if (uiManager.score >= 275)
        {
            AddDifficultyEleven();
        }

        if (uiManager.score >= 300)
        {
            AddDifficultyTwelve();
        }

        if (uiManager.score >= 325)
        {
            AddDifficultyThirteen();
        }

        if (uiManager.score >= 350)
        {
            AddDifficultyFourteen();
        }

        if (uiManager.score == 25 || uiManager.score == 50 || uiManager.score == 75 || uiManager.score == 100 || uiManager.score == 125 || uiManager.score == 150 
            
            || uiManager.score == 175 || uiManager.score == 200 || uiManager.score == 225 || uiManager.score == 250 || uiManager.score == 275 || uiManager.score == 300

            || uiManager.score == 325 || uiManager.score == 350)

        {
            uiManager.DifficultyWarningEnable();
        }
        else
        {
            uiManager.DifficultyWarningDisable();
        }

        if (uiManager.score == 350 && endPoint == false)
        {
            GameObject explosion = Instantiate(explosionPrefab, spawnPoint);

            explosion.transform.localPosition = Vector3.zero;

            endPoint = true;
        }
    }

    void AddDifficultyOne()
    {   
        probeSpawnMin = 1.9f;

        probeSpawnMax = 7.5f;

        enemySpawnMin = 1.9f;

        enemySpawnMax = 7.5f;

        verticalWallSpawnMin = 9.5f;

        verticalWallSpawnMax = 19.0f;

        horizontalWallSpawnMin = 9.5f;

        horizontalWallSpawnMax = 19.0f;
    }

    void AddDifficultyTwo()
    {
        probeSpawnMin = 1.8f;

        probeSpawnMax = 7.0f;

        enemySpawnMin = 1.8f;

        enemySpawnMax = 7.5f;

        verticalWallSpawnMin = 9.0f;

        verticalWallSpawnMax = 18.00f;

        horizontalWallSpawnMin = 9.0f;

        horizontalWallSpawnMax = 18.00f;
    }

    void AddDifficultyThree()
    {
        probeSpawnMin = 1.7f;

        probeSpawnMax = 6.5f;

        enemySpawnMin = 1.7f;

        enemySpawnMax = 6.5f;

        verticalWallSpawnMin = 8.5f;

        verticalWallSpawnMax = 17.0f;

        horizontalWallSpawnMin = 8.5f;

        horizontalWallSpawnMax = 17.0f;
    }

    void AddDifficultyFour()
    {
        probeSpawnMin = 1.6f;

        probeSpawnMax = 6.0f;

        enemySpawnMin = 1.6f;

        enemySpawnMax = 6.0f;

        verticalWallSpawnMin = 8.0f;

        verticalWallSpawnMax = 16.0f;

        horizontalWallSpawnMin = 8.0f;

        horizontalWallSpawnMax = 16.0f;
    }

    void AddDifficultyFive()
    {
        probeSpawnMin = 1.5f;

        probeSpawnMax = 5.5f;

        enemySpawnMin = 1.5f;

        enemySpawnMax = 5.5f;

        verticalWallSpawnMin = 7.5f;

        verticalWallSpawnMax = 15.0f;

        horizontalWallSpawnMin = 7.5f;

        horizontalWallSpawnMax = 15.0f;
    }

    void AddDifficultySix()
    {
        probeSpawnMin = 1.4f;

        probeSpawnMax = 5.0f;

        enemySpawnMin = 1.4f;

        enemySpawnMax = 5.0f;

        verticalWallSpawnMin = 7.0f;

        verticalWallSpawnMax = 14.0f;

        horizontalWallSpawnMin = 7.0f;

        horizontalWallSpawnMax = 14.0f;
    }

    void AddDifficultySeven()
    {
        probeSpawnMin = 1.3f;

        probeSpawnMax = 4.5f;

        enemySpawnMin = 1.3f;

        enemySpawnMax = 4.5f;

        verticalWallSpawnMin = 6.5f;

        verticalWallSpawnMax = 13.0f;

        horizontalWallSpawnMin = 6.5f;

        horizontalWallSpawnMax = 13.0f;
    }

    void AddDifficultyEight()
    {
        probeSpawnMin = 1.2f;

        probeSpawnMax = 4.0f;

        enemySpawnMin = 1.2f;

        enemySpawnMax = 4.0f;

        verticalWallSpawnMin = 6.0f;

        verticalWallSpawnMax = 12.0f;

        horizontalWallSpawnMin = 6.0f;

        horizontalWallSpawnMax = 12.0f;
    }

    void AddDifficultyNine()
    {
        probeSpawnMin = 1.1f;

        probeSpawnMax = 3.5f;

        enemySpawnMin = 1.1f;

        enemySpawnMax = 3.5f;

        verticalWallSpawnMin = 5.5f;

        verticalWallSpawnMax = 11.0f;

        horizontalWallSpawnMin = 5.5f;

        horizontalWallSpawnMax = 11.0f;
    }

    void AddDifficultyTen()
    {
        probeSpawnMin = 1.0f;

        probeSpawnMax = 3.0f;

        enemySpawnMin = 1.0f;

        enemySpawnMax = 3.0f;

        verticalWallSpawnMin = 5.0f;

        verticalWallSpawnMax = 10.0f;

        horizontalWallSpawnMin = 5.0f;

        horizontalWallSpawnMax = 10.0f;
    }

    void AddDifficultyEleven()
    {
        probeSpawnMin = 0.9f;

        probeSpawnMax = 2.5f;

        enemySpawnMin = 0.9f;

        enemySpawnMax = 2.5f;

        verticalWallSpawnMin = 4.5f;

        verticalWallSpawnMax = 9.0f;

        horizontalWallSpawnMin = 4.5f;

        horizontalWallSpawnMax = 9.0f;
    }

    void AddDifficultyTwelve()
    {
        probeSpawnMin = 0.8f;

        probeSpawnMax = 2.0f;

        enemySpawnMin = 0.8f;

        enemySpawnMax = 2.0f;

        verticalWallSpawnMin = 4.0f;

        verticalWallSpawnMax = 8.0f;

        horizontalWallSpawnMin = 4.0f;

        horizontalWallSpawnMax = 8.0f;
    }

    void AddDifficultyThirteen()
    {
        probeSpawnMin = 0.7f;

        probeSpawnMax = 1.5f;

        enemySpawnMin = 0.7f;

        enemySpawnMax = 1.5f;

        verticalWallSpawnMin = 3.5f;

        verticalWallSpawnMax = 7.0f;

        horizontalWallSpawnMin = 3.5f;

        horizontalWallSpawnMax = 7.0f;
    }

    void AddDifficultyFourteen()
    {
        probeSpawnMin = 0.6f;

        probeSpawnMax = 1.0f;

        enemySpawnMin = 0.6f;

        enemySpawnMax = 1.0f;

        verticalWallSpawnMin = 3.0f;

        verticalWallSpawnMax = 6.0f;

        horizontalWallSpawnMin = 3.0f;

        horizontalWallSpawnMax = 6.0f;
    }

    /*IEnumerator DifficultyWarningRoutine()
    {
        uiManager.DifficultyWarningEnable();

        yield return new WaitForSeconds(2f);

        uiManager.DifficultyWarningDisable();

        yield break;
    }*/
}
