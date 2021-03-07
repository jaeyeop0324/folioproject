using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject tramsition;

    public Text totalfruits;
    public Text fruitsCollected;

    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }

    private void Update()
    {
        AllFruitsCollected();
        totalfruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString(); 

    }
    public void AllFruitsCollected()
    {

        if (transform.childCount == 0)
        {
            Debug.Log("더이상 먹을게 없음");
            levelCleared.gameObject.SetActive(true);
            tramsition.SetActive(true);
            Invoke("ChangeScene", 1);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
