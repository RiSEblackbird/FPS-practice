using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // speedを制御する
    public float speed = 10;
    public float power = 100;

/*

    private void FixedUpdate()
    {
        // 入力をxとzに代入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 同一のGameObjectが持つRigidbodyコンポーネントを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        Vector3 vec = new Vector3(x, 0, z);

        vec = vec * speed;

        // rigidbodyのx軸(横)とz軸(奥)に力を加える(speedの適用)
        rigidbody.AddForce(vec);
    }
*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item")) {
            ContactPoint contact = collision.contacts[0];

            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddForce(contact.normal * power);
        }
    }
}
