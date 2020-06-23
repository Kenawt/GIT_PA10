using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Text Score;
    public static int TrueScore;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        TrueScore = 0;
    }

    void Update()
    {
        Score.text = "SCORE : " + Player.TrueScore;
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
        pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 6.6)
        {
            thisAnimation.Play();
            GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);
        }

        if(transform.position.y>=6.7)
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);

        if (transform.position.y <= -4.773493)
            SceneManager.LoadScene("GameLose");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
            SceneManager.LoadScene("GameLose");
    }
}
