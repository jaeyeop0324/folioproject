using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllBasic : MonoBehaviour
{

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;

    private float waitTime;

    public Transform[] moveSpots;

    public float startWaitTime = 2;
    private int i = 0;

    private Vector2 startPos;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {

        StartCoroutine(CheckEnemymoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) < 0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length - 1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemymoving()
    {
        startPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > startPos.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isIdle", false);
        }
        else if (transform.position.x < startPos.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isIdle", false);
        }
        else if (transform.position.x == startPos.x)
        {
            animator.SetBool("isIdle", true);
        }
    }
}
