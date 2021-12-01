using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{

    Rigidbody2D m_Rigidbody;
    public float m_Speed = 10f;



    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody2D>();
        //Set the speed of the GameObject


       
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
        m_Rigidbody.velocity = transform.right * m_Speed;
        
    }
    // when the GameObjects collider arrange for this GameObject to travel to the left of the screen
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);

        if(col.gameObject.name=="RightWall" )
        {
        Destroy(gameObject);
        }

        // if(col.gameObject.name=="bug_0(Clone)")
        // {
        //     Destroy(gameObject);
        //     _mouseManager.bugStrength++;
        //     numberOfHits++;
        //     if(numberOfHits>=numberOfHitsWhenSpawned)
        //     {
        //         Destroy(col.gameObject);
        //     }
        
        
        // }
      
    }
}
