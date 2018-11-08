using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class WeaponContoller : MonoBehaviour {

    // need bullet prefab, firing rate, bullet speed, 
    // need a private gameobject as parent of bullets

    // == constants ==
    private const string SHOOT_METHOD = "Shoot";

    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private float bulletSpeed = 5f;

    [SerializeField]
    private float keyFiringRate = 0.4f;

    [SerializeField]
    private float touchFiringRate = 0.1f;

    private GameObject bulletParent;

    // == private methods ==
    private void Start()
    {
        bulletParent = ParentUtils.FindBulletParent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating(SHOOT_METHOD, 0f, keyFiringRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke(SHOOT_METHOD);
        }

        if (Input.touchCount > 0)
        {
            Invoke(SHOOT_METHOD, keyFiringRate);
        }
        if(Input.touchCount < 0)
        {
            CancelInvoke(SHOOT_METHOD);
        }

    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletParent.transform);
        bullet.transform.position = transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up * bulletSpeed;
        
    }
}
