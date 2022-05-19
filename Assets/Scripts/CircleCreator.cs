using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCreator : MonoBehaviour
{
    [SerializeField] GameObject circle;
    [SerializeField] GameObject bomb;
    [SerializeField] float minTimeBetweenSpawn;
    [SerializeField] float maxTimeBetweenSpawn;
    [SerializeField] float timeBetweenSpawn;
    [SerializeField] float bombTimeBetweenSpawn;
    [SerializeField] float timeMultiply;
    
    float xPos;
    float yPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CircleSpawnCountDown());
        StartCoroutine(BombSpawnCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Circle.timeToDestroy);
    }
    IEnumerator CircleSpawnCountDown()
    {
        while (true)
        {
            if (ScoreHandler.currentScore < 50)
            {
                Circle.timeToDestroy = 3f;
                timeBetweenSpawn = Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn);
                yield return new WaitForSeconds(timeBetweenSpawn);
                SpawnCircle();
                Debug.Log("Stage 1");
            }
            else if(ScoreHandler.currentScore < 150)
            {
                Circle.timeToDestroy = 2.5f;
                timeBetweenSpawn = Random.Range(minTimeBetweenSpawn-.2f, maxTimeBetweenSpawn-.3f);
                yield return new WaitForSeconds(timeBetweenSpawn);
                SpawnCircle();
                Debug.Log("Stage 2");
            }
            else if(ScoreHandler.currentScore < 300)
            {
                Circle.timeToDestroy = 2f;
                timeBetweenSpawn = Random.Range(minTimeBetweenSpawn -.5f, maxTimeBetweenSpawn-1f);
                yield return new WaitForSeconds(timeBetweenSpawn);
                SpawnCircle();
                Debug.Log("Stage 3");
            }
            else
            {
                Circle.timeToDestroy = 1.5f;
                timeBetweenSpawn = Random.Range(minTimeBetweenSpawn - .6f, maxTimeBetweenSpawn - 1.2f);
                yield return new WaitForSeconds(timeBetweenSpawn);
                SpawnCircle();
                Debug.Log("Stage 4");
            }
        }

    }

    IEnumerator BombSpawnCountDown()
    {
        while (true)
        {
            if (ScoreHandler.currentScore < 50)
            {
                bombTimeBetweenSpawn = Random.Range(minTimeBetweenSpawn*timeMultiply, maxTimeBetweenSpawn*timeMultiply);
                yield return new WaitForSeconds(bombTimeBetweenSpawn);
                SpawnBomb();
                Debug.Log("Stage 1");
            }
            else if (ScoreHandler.currentScore < 150)
            {
                bombTimeBetweenSpawn = Random.Range((minTimeBetweenSpawn - .2f)*timeMultiply, (maxTimeBetweenSpawn - .3f)*timeMultiply);
                yield return new WaitForSeconds(bombTimeBetweenSpawn);
                SpawnBomb();
                Debug.Log("Stage 2");
            }
            else if (ScoreHandler.currentScore < 300)
            {
                bombTimeBetweenSpawn = Random.Range((minTimeBetweenSpawn - .5f)*timeMultiply, (maxTimeBetweenSpawn - 1f)*timeMultiply);
                yield return new WaitForSeconds(bombTimeBetweenSpawn);
                SpawnBomb();
                Debug.Log("Stage 3");
            }
            else
            {     
                bombTimeBetweenSpawn = Random.Range((minTimeBetweenSpawn - .6f)*timeMultiply, (maxTimeBetweenSpawn - 1.2f)*timeMultiply);
                yield return new WaitForSeconds(bombTimeBetweenSpawn);
                SpawnBomb();
                Debug.Log("Stage 4");
            }
        }

    }


    private void SpawnCircle()
    {
        xPos = Random.Range(-12f, 12f);
        yPos = Random.Range(-19f, 18f);
        Vector3 newPosition = new Vector3(xPos, yPos, 0f);
        
        var newCircle = Instantiate(circle, newPosition, transform.rotation);
         newCircle.transform.parent = gameObject.transform;

    }

    private void SpawnBomb()
    {
        xPos = Random.Range(-12f, 12f);
        yPos = Random.Range(-19f, 18f);
        Vector3 newPosition = new Vector3(xPos, yPos, 0f);

        var newCircle = Instantiate(bomb, newPosition, transform.rotation);
        newCircle.transform.parent = gameObject.transform;

    }
}
