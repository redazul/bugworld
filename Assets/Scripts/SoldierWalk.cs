using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWalk : MonoBehaviour
{

    public float speed = 10f;
    public GameObject spawnPoint;
    public GameObject pulse;
    public Vector3 target;
    public GameObject GameManager;
    public MouseManger _mouseManager;
    // Start is called before the first frame update

    private float waitTime = 1.0f;
    private float timer = 0.0f;
    void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint");
        GameManager = GameObject.Find("GameManager");
        _mouseManager = GameManager.GetComponent<MouseManger>();
        target = spawnPoint.transform.position;
        int numberOfSoldiers = _mouseManager.numberOfSoldiers;
        target.x = target.x + 0.5f + _mouseManager.xLevel;
        target.y = target.y +  Random.Range(-4.0f, 4.0f);
        
    }

    // Update is called once per frame
    void Update()
    {

        if(_mouseManager.gameOver==false)
        {

               timer += Time.deltaTime;

        // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

         if (timer > waitTime)
        {
            timer=0;
            
        Instantiate(pulse, this.transform.position, Quaternion.identity);

           
        }

        }

      

        
    }
}
