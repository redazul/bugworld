using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;

public class MouseManger : MonoBehaviour
{

    public GridLayout gridLayout;
    public Tilemap _tileMap;
    public GameObject _hoverDetect;

    public bool canBuildSoldier;
    public GameObject soldier;
    public GameObject spawnPoint;

    public int numberOfSoldiers;
    public int xLevel;
    public int bugStrength =0;
    public Text _text;

    public bool gameOver = false;
    public GameObject _gameOverScreen;
    public Text _highscore;
    public float timePassed;
    public Text _timeAlive;
    public Text _numberOfSoldiersText;


    // Start is called before the first frame update
    void Start()
    {
        xLevel=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver!=true)
        {
               gamePlay();
        }else{
            _gameOverScreen.SetActive(true);
            _highscore.text = "HighScore : "+ timePassed.ToString();
        }
     
                 
        
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void gamePlay()
    {

        timePassed +=  Time.deltaTime;
        _timeAlive.text = "Time Alive : "+ timePassed.ToString();
        _numberOfSoldiersText.text = "Number of Soldiers : "+ numberOfSoldiers.ToString();

         

                _text.text = "Bug Strength : " + bugStrength.ToString();
         
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldPoint = ray.GetPoint(-ray.origin.z / ray.direction.z);
            Vector3Int position = _tileMap.WorldToCell(worldPoint);
 
            TileBase tile = _tileMap.GetTile(position);
            //Debug.Log(tile);
            //Debug.Log(_hoverDetect);

            if(tile!=null && tile.name == "tile_flat_base_1 (1)")
            {
                _hoverDetect.SetActive(true);
                canBuildSoldier = true;
            }else{
                _hoverDetect.SetActive(false);
                canBuildSoldier = false;
            }

             if (Input.GetMouseButtonDown(0) && canBuildSoldier==true)
             {
                 Instantiate(soldier, spawnPoint.transform.position, Quaternion.identity);
                 numberOfSoldiers++;
                 bugStrength=bugStrength+10;

                 if(xLevel<3)
                 {
                     xLevel++;
                 }else{
                     xLevel=0;
                 }

             }

    }
}
