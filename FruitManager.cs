using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject tramsition;

    public Text totalfruits;        //총 수량
    public Text fruitsCollected;    //먹은수량

    private int totalFruitsInLevel; //총 수량

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
