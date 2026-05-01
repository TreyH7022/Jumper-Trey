using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class UIScripts : MonoBehaviour
{
    private float highscore = 0f;
    private bool isGameOver = false;

    public Transform player;
    public Camera cam;
    public TextMeshProUGUI scoreText;
    public GameObject ggPanel;
    public float screenOffSet = 1f;

    public AudioSource audioSource;
    public AudioClip backgroundMusic;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ggPanel.SetActive(false);
        Time.timeScale = 1f;

        highscore = PlayerPrefs.GetFloat("Highscore", 0f);       

        audioSource.PlayOneShot(backgroundMusic); 

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver) return;

        float altitude = Mathf.Max(0, player.position.y);
        if (altitude > highscore)
        {
            highscore = altitude;
            PlayerPrefs.SetFloat("Highscore", highscore);
        }

        scoreText.text =
            "Altitude: " + Mathf.FloorToInt(altitude) +
            "\nHighscore: " + Mathf.FloorToInt(highscore);

        float cameraBottom = cam.transform.position.y - cam.orthographicSize;

        if (player.position.y < cameraBottom - screenOffSet)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        ggPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
