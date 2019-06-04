using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    static public int score;
    public int lifes;
    public float insensibilityTime;
    public float blinkingPeriod;

    private bool insensibility;
    private float remainingInsenTime;
    private float remainingBlinkTime;

    public Animator camAnim;

    public TextMeshProUGUI scoreTextMesh;
    public TextMeshProUGUI lifesTextMesh;

    public AudioClip crash_clip;
    public AudioSource crash;

    public AudioClip money_clip;
    public AudioSource money_sound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        insensibility = true;
        remainingInsenTime = insensibilityTime;
        remainingBlinkTime = blinkingPeriod;
        crash.clip = crash_clip;
        money_sound.clip = money_clip;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        scoreTextMesh.text = "Score: " + score.ToString();
        lifesTextMesh.text = "Lifes: " + lifes.ToString();

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (remainingInsenTime <= 0)
        {
            insensibility = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            remainingInsenTime -= Time.deltaTime;
            if (remainingBlinkTime <= 0)
            {
                if (gameObject.GetComponent<SpriteRenderer>().color.a == 1)
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
                else
                    gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                remainingBlinkTime = blinkingPeriod;
            }
            else
            {
                remainingBlinkTime -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public bool isInsensibility()
    {
        return insensibility;
    }

    public void decreaseLife()
    {
        lifes--;
        if(lifes == 0)
        {
            SceneManager.LoadScene(2);
        }
        insensibility = true;
        remainingInsenTime = insensibilityTime;
        remainingBlinkTime = blinkingPeriod;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
    }
}
