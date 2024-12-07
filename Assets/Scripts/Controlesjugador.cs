using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlesjugador : MonoBehaviour
{
    [SerializeField] private float velocidad = 15f; //Serializefield, muestra las variables en Unity
    [SerializeField] private float sensibilidadMouse = 10000f;

    private float rotacionY = 10f;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; //Hace que no moleste el cursor
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movimiento = transform.right * horizontal + transform.forward * vertical;
        rb.AddForce(movimiento.normalized * velocidad);

        //Movimiento cámara
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse;
        rotacionY += mouseX; // Acumula la rotación en el eje Y

        transform.rotation = Quaternion.Euler(0f, rotacionY, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Salida"))
        {
            Debug.Log("Lo has conseguido, felicidades");

        }


    }
}
