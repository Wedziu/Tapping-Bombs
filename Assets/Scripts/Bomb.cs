using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] float timer;
    void Start()
    {
        SpriteRenderer currentSprite = GetComponent<SpriteRenderer>();
        int selectedSprite = Random.Range(0, sprites.Length);
        currentSprite.sprite = sprites[selectedSprite];
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>2f)
        {
            Destroy(gameObject);
        }
    }
}
