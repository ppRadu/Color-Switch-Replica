using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;
    public static int score = 0;
    public Text scoreText;

    public GameObject obstacle;
    public float obstacleDistance = 5f;

    public Color blue;
    public Color yellow;
    public Color pink;
    public Color purple;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        scoreText.text = score.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Scored")
        {
            score++;
            Destroy(collision.gameObject);
            return;
        }

        if (collision.tag == "ColorSwitcher")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            Instantiate(obstacle, new Vector2(transform.position.x, transform.position.y + obstacleDistance), transform.rotation);
            return;
        }

        if (collision.tag != currentColor)
        {
            Debug.Log("You Died!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            score = 0;
        }

    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = blue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = yellow;
                break;
            case 2:
                currentColor = "Pink";
                sr.color = pink;
                break;
            case 3:
                currentColor = "Purple";
                sr.color = purple;
                break;
            default:
                break;
        }
    }
}
