using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGameActive = false;
    public bool isGamePausable;
    public int lives = 0;
    
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject trail;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] Camera cam;
    private float spawnRate = 1.0f;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PauseOrUnpause();
        CreateTrail();
    }

    private void CreateTrail()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isGameActive)
        {
            Vector2 mousePos = new Vector2();
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            Instantiate(trail, cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10)), trail.transform.rotation);
        }
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int currentLives)
    {
        lives = currentLives;
        livesText.text = "Lives: " + lives;
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void LoseLife()
    {
        lives--;
        UpdateLives(lives);
        if (lives <= 0)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            isGameActive = false;
            isGamePausable = false;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        isGamePausable = true;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());

        UpdateScore(0);
        UpdateLives(3);
        titleScreen.gameObject.SetActive(false);
    }

    private void PauseOrUnpause()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGamePausable)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                isGameActive = false;
                pauseScreen.gameObject.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                isGameActive = true;
                pauseScreen.gameObject.SetActive(false);
            }
        }
    }
}
