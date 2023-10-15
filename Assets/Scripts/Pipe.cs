using UnityEngine;

public class Pipe : MonoBehaviour
{
    public static float speed;
    public float startX;
    public float endX;

    private void Start()
    {
        startX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0)).x - 1;
        endX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0)).x + 1;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < startX)
        {
            var height = Random.Range(-2.5f, 3.5f);
            transform.position = new Vector3(endX, height);
        }
    }
}
