using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    bool followStill = true;
    
    Camera cam;
    Vector2 mousePos = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && followStill)
        {
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
            Vector3 followerPos = new Vector3(mousePos.x, mousePos.y, 10);
            transform.position = cam.ScreenToWorldPoint(followerPos);
        }
        else
        {
            followStill = false;
            StartCoroutine(FinalCountdown());
        }
    }

    IEnumerator FinalCountdown()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
