using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Circle : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] int pointsToAdd = 10;
    [SerializeField] float timer = 0f;
    [SerializeField] public static float timeToDestroy;
    [SerializeField] public static int destroyedCircles;
    ScoreHandler scoreHandler;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer currentSprite = GetComponent<SpriteRenderer>();
        int selectedSprite = Random.Range(0, sprites.Length);
        currentSprite.sprite = sprites[selectedSprite];
        scoreHandler = FindObjectOfType<ScoreHandler>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            
            RaycastHit2D hitInfo = Physics2D.Raycast(touchPosition, Camera.main.transform.transform.forward);
            if(hitInfo.collider!=null)
            {
                if (hitInfo.collider.gameObject.tag != "Bomb")
                {
                    destroyedCircles++;
                    ScoreHandler.currentScore += pointsToAdd;
                    GameObject touchedObject = hitInfo.transform.gameObject;
                    Destroy(touchedObject);
                }
                else if (hitInfo.collider.gameObject.tag == "Bomb")
                {
                    scoreHandler.EndGame();
                    GameObject touchedObject = hitInfo.transform.gameObject;
                    
                }
                
            }

        }
        if (timer > timeToDestroy)
        {
            Debug.Log("LoadMenu");
            scoreHandler.EndGame();
        }
    }

  
}
