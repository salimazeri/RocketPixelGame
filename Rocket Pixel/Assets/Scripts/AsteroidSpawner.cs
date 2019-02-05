using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AsteroidSpawner : MonoBehaviour {

    public GameObject asteroid_0, asteroid_1, asteroid_2, asteroid_3;
    public GameObject rocket;
    static GameObject[] asteroidArray = new GameObject[4];
    
    public Button restartButton;

    public float speed = 200;
    public float nextSpawn = 0f;
    public float spawnRate = 2f;
    int score = 0;
    public Text scoreText;
    
    
	// Use this for initialization
	void Start () {
        score = 0;
        asteroidArray[0] = asteroid_0;
        asteroidArray[1] = asteroid_1;
        asteroidArray[2] = asteroid_2;
        asteroidArray[3] = asteroid_3;
        restartButton.onClick.AddListener(TaskOnClick);

    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("rocket 2", LoadSceneMode.Single);
    }

    

    // Update is called once per frame
    void FixedUpdate () {
        scoreText.text = score.ToString();

        Vector3 randomVector = new Vector3(Random.Range(-50, 50), 120, 0);
        Vector2 speedVector = new Vector2(0,-10);

        

        if (Time.time > nextSpawn)
        {

            GameObject clone;
            Vector3 clone_pos;

            nextSpawn = Time.time + spawnRate;
            
            //Tworzenie klonów asteroid.
            clone = Instantiate(asteroidArray[Random.Range(0, 3)], randomVector, Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)))) as GameObject;
            clone.AddComponent<Rigidbody2D>();
            clone_pos = randomVector;

            Rigidbody2D cloneRB;
            cloneRB = clone.GetComponent<Rigidbody2D>();
            cloneRB.AddForce(speedVector * speed);


            clone.transform.position = transform.TransformPoint(clone_pos);

            //usuwanie klonów gdy ich wartość Y osiagnie mniej niż -150
            foreach (GameObject clone_ in GameObject.FindGameObjectsWithTag("asteroid_clone"))
            {
                if (clone_.transform.position.y < -150)
                {
                    Destroy(clone_);
                }
            }

            //dodawanie punktów gdy asteroida minie rakietę.
            foreach (GameObject clone_ in GameObject.FindGameObjectsWithTag("asteroid_clone"))
            {
                if (clone_.transform.position.y < rocket.transform.position.y-10)
                {
                    score += 1;
                }
            }



            speed += 1;
        }

        

        
    }
}
