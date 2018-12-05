﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class WeaponContoller : MonoBehaviour {

    // need bullet prefab, firing rate, bullet speed, 
    // need a private gameobject as parent of bullets


    // == constants ==
    private const string SHOOT_METHOD = "Shoot";
    // == Weapons ==
    [SerializeField]
    private Bullet bulletPrefab;
    [SerializeField]
    private float bulletSpeed = 5f;
    private float firingRate = 0.2f;

    [SerializeField]
    private AudioClip playerShot;

    private GameObject bulletParent;
    private SoundController soundController;


    // == private methods ==
    private void Start()
    {
        bulletParent = ParentUtils.FindBulletParent();
        soundController = SoundController.FindSoundController();
        InvokeRepeating(SHOOT_METHOD, 0f, firingRate);

    }

    private void Update()
    {
        if (GameController.tempTokenCollected == 3)
        {
            //Debug.Log("Coroutine started");
            StartCoroutine(Special());
        }
    }
    
    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletParent.transform);
        bullet.transform.position = transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up * bulletSpeed;
        if (soundController)
        {
            soundController.PlayOneShot(playerShot);
        }
    }

    IEnumerator Special()
    {
        GameController.tempTokenCollected = 0;
        //Debug.Log("Special intiated");
        CancelInvoke(SHOOT_METHOD);
        firingRate -= 0.1f;
        InvokeRepeating(SHOOT_METHOD, 0f, firingRate);
        //Debug.Log("Firing rate before wait" + firingRate);
        //Debug.Log("Damage before wait: " + firingRate);
        yield return new WaitForSecondsRealtime(10);
        CancelInvoke(SHOOT_METHOD);
        firingRate += 0.1f;
        //Debug.Log("Firing rate after wait" + firingRate);
        InvokeRepeating(SHOOT_METHOD, 0f, firingRate);
        //Debug.Log("Damage after wait: " + firingRate);

    }
}
