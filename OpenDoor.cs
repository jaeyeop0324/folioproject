using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoor : MonoBehaviour
{
    public Text text;
    public string levelName;
    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (levelName == "Level4")
            {
                text.text = "미구현 상태입니다.";
                text.gameObject.SetActive(true);
            }
            else
            {
                text.text = $"Plase 'E' Key Press";
                text.gameObject.SetActive(true);
                inDoor = true;
            }
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        text.gameObject.SetActive(false);
        inDoor = false;   
    }


    private void Update()
    {
        if (inDoor && (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            Debug.Log(levelName);
            if (levelName == "Level4")
            {
                return;
            }
            else
            {
                SceneManager.LoadScene(levelName);
            }
            
        }
    }

}
