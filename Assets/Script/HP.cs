using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int hitPoint = 100;

    public GameObject Explosion;

    void Update()
    {
        if (hitPoint <= 0)
        {
            Destroy(gameObject);

            Explosion.SetActive(true);

            Instantiate(Explosion, Explosion.transform.position, Quaternion.identity);
        }
    }

    public void Damage(int damage)
    {
        hitPoint -= damage;

    }
}
