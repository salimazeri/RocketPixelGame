using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    GameObject player, guzik;
    Vector3 touchPosWorld;
    TouchPhase touchPhase = TouchPhase.Ended;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("rocket2_0");
        guzik = GameObject.Find("Guzik");
        InvokeRepeating("CustomUpdate", 0.1f, 0.001f);
    }

    // Update is called once per frame
    void CustomUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary) ;
            {
                Debug.Log("Touching");
                //We transform the touch position into word space from screen space and store it.
                touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

                //We now raycast with this information. If we have hit something we can process it.
                RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

                if (hitInformation.collider.name == "Guzik")
                {
                    player.transform.position = new Vector2(touchPosWorld.x, player.transform.position.y);
                    guzik.transform.position = new Vector2(touchPosWorld.x, guzik.transform.position.y);
                }
            }
        }
    }
}