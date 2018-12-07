using System.Collections;
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
    private GameObject bulletParent;

    // == sounds ==
    [SerializeField]
    private AudioClip playerShot;
    private SoundController soundController;

    // == private methods ==
    private void Start()
    {
        bulletParent = ParentUtils.FindBulletParent();
        soundController = SoundController.FindSoundController();// get sound controller to play sound effects
        InvokeRepeating(SHOOT_METHOD, 0f, firingRate);// invoked once the game starts

    }

    private void Update()
    {
        if (GameController.tempTokenCollected == 5)// checks if fire rate should be increased
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
            soundController.PlayOneShot(playerShot);// plays sound effect
        }
    }

    IEnumerator Special()
    {
        GameController.tempTokenCollected = 0;
        //Debug.Log("Special intiated");
        CancelInvoke(SHOOT_METHOD);
        firingRate -= 0.1f;// increases the firing rate 
        InvokeRepeating(SHOOT_METHOD, 0f, firingRate);
        //Debug.Log("Firing rate before wait" + firingRate);
        //Debug.Log("Damage before wait: " + firingRate);
        yield return new WaitForSecondsRealtime(10);
        CancelInvoke(SHOOT_METHOD);
        firingRate += 0.1f;// resets the firing rate
        //Debug.Log("Firing rate after wait" + firingRate);
        InvokeRepeating(SHOOT_METHOD, 0f, firingRate);
        //Debug.Log("Damage after wait: " + firingRate);

    }
}
