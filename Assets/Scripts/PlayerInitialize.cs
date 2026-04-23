using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitialize : MonoBehaviour
{
    void Start()
    {
        // 1. Obtener la cámara principal
        Camera cam = Camera.main;

        // 2. Calcular el borde derecho de la pantalla en unidades del mundo (Z es la distancia a la cámara)
        Vector3 bordeIzquierdo = cam.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, cam.nearClipPlane));

        // 3. Establecer la posición del personaje (ajustando opcionalmente el borde)
        transform.position = new Vector3(bordeIzquierdo.x + 5f, 0, 0); // -1.0f para que no esté justo en el borde
    }

    public void StartAgain()
    {
        Start();
    }

}
