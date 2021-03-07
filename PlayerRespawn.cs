using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    private float checkPointPoitionX, checkPointPoitionY;

    public Animator animator;
    public GameObject[] hearts;
    private int life;
    private bool DamegeDelay = true;
    
    void Start()
    {
        life = hearts.Length;

        if (PlayerPrefs.GetFloat("checkPointPoitionX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPoitionX"), PlayerPrefs.GetFloat("checkPointPoitionY"));
        }
    
    }
    IEnumerator CheckLife()
    {
        if (DamegeDelay)
        {
            DamegeDelay = false;
            life--;
            Destroy(hearts[life].gameObject);
            animator.Play("Hit");
            if (life < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            yield return new WaitForSeconds(1f);

            DamegeDelay = true;
        }
        
        yield return null;
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPoitionX", x);
        PlayerPrefs.SetFloat("checkPointPoitionY", y);
    }

    public void PlayerDamaged()
    {
        StartCoroutine("CheckLife");
    }

}
