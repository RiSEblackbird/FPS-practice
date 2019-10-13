using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public int damage;
    private GameObject enemy;
    private HP hp;
       
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
        hp = enemy.GetComponent<HP>();
    }

    /* この場合はこりだーのトリガーにチェック！
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            hp.Damage(damage);

            Destroy(other.gameObject);
        }
    }
    */

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shell"))
        {
            hp.Damage(damage);

            Destroy(other.gameObject);
            
        }
    }
}
