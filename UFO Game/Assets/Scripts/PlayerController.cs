using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;

    private Rigidbody2D rb2d;
    private int count;
    private int damage;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        damage = 3;

        winText.text = "";
        SetCountText();
        SetLivesText();
    }

    void FixedUpdate ()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("PickUp2"))
        {
            other.gameObject.SetActive(false);
            damage = damage - 1;
            SetLivesText();
        }

        if (count == 12)
        {
            transform.position = new Vector2(100.0f, -10.0f);

        }


    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You win! Game created by Sean Bergeron.";
        }
    }
  
    void SetLivesText()
    {
        livesText.text = "Lives: " + damage.ToString();
        if (damage == 0)
        {
            winText.text = "You lose!";
            Destroy(gameObject);
        }
    }
}
