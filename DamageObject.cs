using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public static bool isDamege;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //isDamege = true;
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //isDamege = false;
            collision.transform.GetComponent<PlayerRespawn>().PlayerDamaged();
        }
    }

}
