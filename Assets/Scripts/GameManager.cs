using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text _text;
    private float waitTime = 1.0f;
    private float timer = 0.0f;
    public int countDown = 59;

    public GameObject _bug;
    public GameObject _spawnPoint;
    public GameObject _fire;
    public GameObject _firePosition;
    public float speed = 5f;
    public GameObject _canvas;
    //Rigidbody2D bulletInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown>=0)
        {
             timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        // Subtracting two is more accurate over time than resetting to zero.
        if (timer > waitTime)
        {
            timer = 0f;
            _text.text = countDown.ToString();
            countDown--;

            //spawn randomly
            Vector3 _trueSpawn = _spawnPoint.transform.position;
            _trueSpawn.y = Random.Range(-5.0f, 5.0f);
            Instantiate(_bug, _trueSpawn, Quaternion.identity);

            
        }

         if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pressed primary button.");
            //...setting shoot direction
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection = shootDirection-transform.position;
            //...instantiating the rocket
            GameObject bulletInstance = Instantiate(_fire, _firePosition.transform.position, Quaternion.identity);
            bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
        
         }

        }else{
            _canvas.SetActive(true);
        }
       


        
    }
}
