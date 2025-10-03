using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public static event System.Action<DestroyObject> EnemyDestroyed;

    public int damage;
    private GameObject tmpenemy;
    private GameObject enemy;
    public GameObject Explosion;
    public GameObject Particles;

    public int hitPoint = 100;
    private bool isDestroyed;

    void Start()
    {
        tmpenemy = GameObject.FindWithTag("Enemy");
        name = tmpenemy.name.ToString();
        enemy = GameObject.Find(name);
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

    public void Damage(int damage)
    {
        hitPoint -= damage;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Shell"))
        {
            Damage(damage);

            Particles.SetActive(true);

            Instantiate(Particles, other.gameObject.transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            
        }
    }

    void Update()
    {
        if (!isDestroyed && hitPoint <= 0)
        {
            isDestroyed = true;

            EnemyDestroyed?.Invoke(this);

            Destroy(gameObject);

            Explosion.SetActive(true);

            Instantiate(Explosion, Explosion.transform.position, Quaternion.identity);

        }
    }
}
