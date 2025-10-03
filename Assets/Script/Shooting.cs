using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject Mazzleflash;
    public GameObject MF;
    public Vector3 BulletScale;
    public Vector3 MFScale;
    public Quaternion MFRotation;
    public float shotSpeed;
    public int shotCount = 200;
    [SerializeField] private InputActionReference fireAction;
    [SerializeField] private InputActionReference reloadAction;

    private int shotInterval;
    private bool isFiring;

    private void OnEnable()
    {
        if (fireAction != null && fireAction.action != null)
        {
            fireAction.action.started += OnFireStarted;
            fireAction.action.canceled += OnFireCanceled;
            fireAction.action.Enable();
        }

        if (reloadAction != null && reloadAction.action != null)
        {
            reloadAction.action.performed += OnReloadPerformed;
            reloadAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (fireAction != null && fireAction.action != null)
        {
            fireAction.action.started -= OnFireStarted;
            fireAction.action.canceled -= OnFireCanceled;
            fireAction.action.Disable();
        }

        if (reloadAction != null && reloadAction.action != null)
        {
            reloadAction.action.performed -= OnReloadPerformed;
            reloadAction.action.Disable();
        }
    }

    private void Update()
    {
        if (isFiring)
        {
            shotInterval += 1;

            if (shotInterval % 2 == 0 && shotCount > 0)
            {
                FireBullet();
            }
        }
        else
        {
            shotInterval = 0;
        }

        Mazzleflash.SetActive(false);
    }

    private void OnFireStarted(InputAction.CallbackContext context)
    {
        isFiring = true;
    }

    private void OnFireCanceled(InputAction.CallbackContext context)
    {
        isFiring = false;
    }

    private void OnReloadPerformed(InputAction.CallbackContext context)
    {
        shotCount = 200;
    }

    private void FireBullet()
    {
        shotCount -= 1;

        Mazzleflash.SetActive(true);

        MF = Instantiate(Mazzleflash, transform.position, transform.rotation);
        MF.transform.SetParent(gameObject.transform);
        MF.transform.localScale = MFScale;
        MF.transform.localRotation = MFRotation;

        GameObject bullet = Instantiate(bulletPrefab, Mazzleflash.transform.position, Mazzleflash.transform.rotation);
        bullet.transform.localScale = BulletScale;

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * shotSpeed);

        Destroy(bullet, 5.0f);
    }
}
