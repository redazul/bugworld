using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    public GameObject bug;
    public GameObject spawnPoint;
    public Vector3 _position;

    private float waitTime = 1.0f;
    private float timer = 0.0f;

    public GameObject GameManager;
    public MouseManger _mouseManager;
    public int numberOfHitsWhenSpawned;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        _mouseManager = GameManager.GetComponent<MouseManger>();
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if(_mouseManager.gameOver==false)
        {
                    numberOfHitsWhenSpawned = _mouseManager.bugStrength;
         timer += Time.deltaTime;
        

        if (timer > waitTime)
        {
            timer=0;

       
        _position = spawnPoint.transform.position;
        _position.y = Random.Range(-4.0f, 4.0f);
        Instantiate(bug, _position, Quaternion.identity);
        //Debug.Log(numberOfHitsWhenSpawned.ToString() + " " + i.ToString());
    


        }


           
        }
    }
}
