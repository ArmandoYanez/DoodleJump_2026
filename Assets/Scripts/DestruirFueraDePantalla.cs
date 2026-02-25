using UnityEngine;

public class DestruirFueraDePantalla : MonoBehaviour
{
    // El "margen" para que no desaparezcan justo en el borde
    public float margen = 2f; 

    void Update()
    {
        // Obtenemos la posición del objeto en el espacio de la cámara
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);

        // Verificamos si está fuera de los límites (0 a 1) más el margen
        if (viewportPos.x < -margen || viewportPos.x > 1 + margen || 
            viewportPos.y < -margen || viewportPos.y > 1 + margen)
        {
            Destroy(gameObject);
        }
    }
}