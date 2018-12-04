using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class WeaponContoller : MonoBehaviour {

    // need bullet prefab, firing rate, bullet speed, 
    // need a private gameobject as parent of bullets


    // == constants ==
    private const string KEY_SHOOT_METHOD = "KeyShoot";
    private const string TOUCH_SHOOT_METHOD = "TouchShoot";

    private bool isShooting = false;

    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private float bulletSpeed = 5f;

    private float keyFiringRate = 0.2f;

    [SerializeField]
    private AudioClip playerShot;

    private GameObject bulletParent;
    private SoundController soundController;


    // == private methods ==
    private void Start()
    {
        bulletParent = ParentUtils.FindBulletParent();
        soundController = SoundController.FindSoundController();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating(KEY_SHOOT_METHOD, 0f, keyFiringRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke(KEY_SHOOT_METHOD);
        }
        
        if (Input.touchCount > 0 && !isShooting)
        {
            isShooting = true;
            Invoke(TOUCH_SHOOT_METHOD, 0.2f);
        }
        if(Input.touchCount < 0)
        {
            CancelInvoke(TOUCH_SHOOT_METHOD);
        }

        if (GameController.tempTokenCollected == 5)
        {
            Debug.Log("Coroutine started");
            StartCoroutine(Special());
        }
    }

    private void KeyShoot()
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

    private void TouchShoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletParent.transform);
        bullet.transform.position = transform.position;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.up * bulletSpeed;
        isShooting = false;
        if (soundController)
        {
            soundController.PlayOneShot(playerShot);
        }
    }

    IEnumerator Special()
    {
        GameController.tempTokenCollected = 0;
        //Debug.Log("Special intiated");
        //keyFiringRate = 0.1f;
        Enemy.damageToGive += 10;
        //Debug.Log("Firing rate before wait" + keyFiringRate);
        Debug.Log("Damage before wait: " + Enemy.damageToGive);
        yield return new WaitForSecondsRealtime(5);
        Enemy.damageToGive -= 10;
        //keyFiringRate = 0.2f;
        Debug.Log("Damage after wait: " + Enemy.damageToGive);

    }
}
