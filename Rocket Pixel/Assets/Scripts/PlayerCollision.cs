using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollision : MonoBehaviour
{
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;
    public GameObject hp1, hp2, hp3;
    int hp = 3;
    void Update()
    {
        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
        }

        if (hp == 2)
        {
            hp3.GetComponent<Renderer>().enabled = false;
        }
        if (hp == 1)
        {
            hp2.GetComponent<Renderer>().enabled = false;
        }
        if (hp == 0)
        {
            hp1.GetComponent<Renderer>().enabled = false;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
    }
    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        collider.enabled = false;
        startBlinking = true;
        hp -= 1;
        yield return new WaitForSeconds(2);
        collider.enabled = true;
    }
    public void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;  //make changes
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().enabled = true;   //make changes
            }
        }
    }
}









