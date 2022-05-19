using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTouch : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
   
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            RaycastHit2D hitInfo = Physics2D.Raycast(touchPosition, Camera.main.transform.transform.forward);
            Instantiate(particles, touchPosition, transform.rotation);
        }
    }
}
