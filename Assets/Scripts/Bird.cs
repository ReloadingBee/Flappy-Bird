using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public int score = 0;
    public TMP_Text scoreText;
    public AudioSource scoreSound;

    private readonly float rotatePower = 3;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
        scoreSound.Play();
    }
}
