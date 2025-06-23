using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter : MonoBehaviour
{
    RaycastHit rayHitData;
    [SerializeField] GameObject growBullet;
    [SerializeField] GameObject shrinkBullet;
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject gunObject;
    [SerializeField] ParticleSystem growParticles;
    [SerializeField] ParticleSystem shrinkParticles;
    [SerializeField] GameObject gunEnd;
    [SerializeField] float bulletDuration=0.75f;
    [SerializeField] AudioClip growSound;
    [SerializeField] AudioClip shrinkSound;
    [SerializeField] float volume=0.5f;
    public bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        canFire=true;
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (canFire)
            {
                if (Input.GetMouseButtonDown(0)) // Left Click
                {
                    Fire();
                }
                else if (Input.GetMouseButtonDown(1)) // Right Click
                {
                    AltFire();
                }
            }
        }
    }

    void Fire(){
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // if(Physics.Raycast(ray, out rayHitData)){
        //     string hittag=rayHitData.collider.tag;
        //     Debug.Log(hittag);
        // }
        if(canFire){
            BulletBehavior(growBullet,growSound,growParticles);
        }
        
    }

    void AltFire(){
        if(canFire){
            BulletBehavior(shrinkBullet,shrinkSound,shrinkParticles);
        }
        
    }

    void BulletBehavior(GameObject bullet, AudioClip bulletAudio, ParticleSystem gunParticles){
        GameObject bulletInstance=Instantiate(bullet, Camera.main.transform.position, shrinkBullet.transform.rotation);
        Rigidbody bulletRb=bulletInstance.GetComponent<Rigidbody>();
        bulletRb.AddForce(Camera.main.transform.forward*bulletSpeed*Time.fixedDeltaTime, ForceMode.Impulse);
        ParticleSystem particles=Instantiate(gunParticles,gunEnd.transform.position, gunEnd.transform.rotation);
        AudioSource.PlayClipAtPoint(bulletAudio, Camera.main.transform.position,volume);
        Destroy(bulletInstance,bulletDuration);
        Destroy(particles.gameObject,0.5f);
    }


}
