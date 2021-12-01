using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugWalk : MonoBehaviour
{

    AudioSource _as;
    public GameObject _base;
    public float speed = 10f;

    public GameObject GameManager;
    public MouseManger _mouseManager;

    public int numberOfHits = 0;
    public int numberOfHitsWhenSpawned = 0;



    
    // Start is called before the first frame update
    void Start()
    {
        //GameObject bg = GameObject.Find("Background");
        //_as = bg.GetComponent<AudioSource>();
        GameManager = GameObject.Find("GameManager");
        _mouseManager = GameManager.GetComponent<MouseManger>();
        numberOfHitsWhenSpawned = _mouseManager.bugStrength;
        //speed = numberOfHitsWhenSpawned+1f;
        speed = 0.2f;


    }

    // Update is called once per frame
    void Update()
    {
                // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, _base.transform.position, step);
    }


      // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);

        

          if(col.gameObject.name=="SpawnPoint")
        {
            Debug.Log("GameOver");
            _mouseManager.gameOver = true;
        }


        if(col.gameObject.name=="pulse1(Clone)")
        {
            
  
            numberOfHits++;
            if(numberOfHits>=numberOfHitsWhenSpawned)
            {
                Destroy(gameObject);
              _mouseManager.bugStrength++;
               
            }

             Destroy(col.gameObject);

            
        
        
        }
      
    }

  

}
