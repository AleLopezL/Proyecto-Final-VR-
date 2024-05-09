using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] int bulletSpeed = 20;
    public Camera playerCamera;
    public Animator animator;
    // Referencia al LineRenderer

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnShoot()
    {
        animator.SetTrigger("isShoot");
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("isShoot")) 
        {
              // Creamos el Raycast que apunte desde la cámara al centro de la pantalla
            Ray rayo = new Ray(firePoint.position,firePoint.right);
            RaycastHit hit;


            // -------------------------------------------------
            // Primero se verifica si el rayo ha golpeado algo
            // -------------------------------------------------
            if (Physics.Raycast(rayo, out hit)) {

                // Obtener el punto de impacto del rayo visual
                Vector3 puntoImpacto = hit.point;

                


                // Instanciar la bala y establecer su dirección hacia el punto de impacto
                //GameObject balaImpacto = Instantiate(bulletPrefab, firePoint);
                //balaImpacto.transform.SetParent(null);
                //Vector3 direccionImpacto = (puntoImpacto - firePoint.transform.position).normalized;
                // balaImpacto.GetComponent<Rigidbody>().velocity = direccionImpacto * bulletSpeed;
                GameObject bullet = ObjectPool.instance.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = firePoint.position; // Colocamos el objeto en la posición
                    bullet.SetActive(true); // Activamos el objeto del pool
                    Vector3 direccionImpacto = (puntoImpacto - firePoint.transform.position).normalized;
                    bullet.GetComponent<Rigidbody>().velocity = direccionImpacto * bulletSpeed;
                }


            }
            else {

                // --------------------------------------------------------------
                // Si el rayo no ha golpeado nada, simplemente se extiende lejos
                // --------------------------------------------------------------

                // Si el rayo no golpea nada, extenderlo lejos
              

                // Instanciar la bala y establecer su dirección hacia el punto lejano
              //  GameObject bullet = Instantiate(bulletPrefab, firePoint);
              //  bullet.transform.SetParent(null);

                // Obtener la dirección hacia el punto final del rayo visual
                Vector3 puntoLejano = rayo.GetPoint(100);
                Vector3 direccion = (puntoLejano - firePoint.transform.position).normalized;
                // bullet.GetComponent<Rigidbody>().velocity = direccion * bulletSpeed;
                GameObject bullet = ObjectPool.instance.GetPooledObject();
                if (bullet != null)
                {
                    bullet.transform.position = firePoint.position; // Colocamos el objeto en la posición
                    bullet.SetActive(true); // Activamos el objeto del pool
                    bullet.GetComponent<Rigidbody>().velocity = direccion * bulletSpeed;
                }


            }
        }
       
    }
    }
