using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public TMP_Text scoreText;
    public AudioSource scoreSound;
    public GameObject endScreen;
    public GameObject bgDay;
    public GameObject bgNight;
    public GameObject yellow;
    public GameObject blue;
    public GameObject red;

    public int score = 0;
    public float jumpSpeed;
    public float speed;
    Rigidbody2D rb;

    private readonly float rotatePower = 3;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;
        bool isDay = (Random.value > 0.5f); // 0 = false; 1 = day

        if (isDay)
        {
            bgDay.SetActive(true);
            bgNight.SetActive(false);

            if (Random.value > 0.5f) // false = yellow; true = blue
            {
                yellow.SetActive(false);
                blue.SetActive(true);
                red.SetActive(false);
            }
            else
            {
                yellow.SetActive(true);
                blue.SetActive(false);
                red.SetActive(false);
            }
        }
        else
        {
            bgDay.SetActive(false);
            bgNight.SetActive(true);

            yellow.SetActive(false);
            blue.SetActive(false);
            red.SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;

        Invoke("ShowMenu", 1f);

        //var currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);
    }

    void ShowMenu()
    {
        endScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
        scoreSound.Play();
    }
}
