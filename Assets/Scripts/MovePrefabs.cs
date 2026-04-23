using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrefabs : MonoBehaviour
{
    private float posInicial, longitud;
    public float velocidad = 5f; //Velocidad del fondo
    public float parallaxEffect; //Velocidad relativa a la que el fondo debe moverse
    public float aceleracion = 0.2f;
    void Start()
    {
        posInicial = transform.position.x; //Solo horizontalmente
        longitud = GetComponent<SpriteRenderer>().bounds.size.x; //Obtener la longitud de la imagen de fondo
    }

    // Update is called once per frame
    void Update()
    {
        if (velocidad < 12f)
        {
            velocidad += aceleracion * Time.deltaTime;
        }


        float movimiento = velocidad * Time.deltaTime; //Movimiento a la izquierda
        transform.position += Vector3.left * movimiento * parallaxEffect; //Aplicar parallax
    }
}
