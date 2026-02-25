using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [Header("Prefabs de Plataformas")]
    public GameObject[] plataformaPrefabs; // Aquí pones la normal, la que se rompe y la de aceleración
    
    [Header("Configuración de Spawneo")]
    public Transform camaraTransform;      // Arrastra la Cámara Principal aquí
    public float distanciaEntrePlataformas = 2f; // Distancia vertical aproximada
    public float distanciaEntrePlataformasA = 2f; // Distancia vertical aproximada
    public float anchoNivel = 3f;          // Qué tan lejos a la izquierda/derecha aparecen
    
    private float alturaSiguientePlataforma = 0f;
    private float spawnThreshold = 10f;    // Cuánta distancia adelante de la cámara generar

    void Start()
    {
        // Generamos las primeras 10 plataformas al iniciar
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Si la cámara sube lo suficiente, generamos una nueva plataforma adelante
        if (camaraTransform.position.y + spawnThreshold > alturaSiguientePlataforma)
        {
            SpawnPlatform();
        }
    }

    void SpawnPlatform()
    {
        // 1. Elegir posición aleatoria
        Vector3 spawnPosition = new Vector3();
        spawnPosition.y = alturaSiguientePlataforma;
        spawnPosition.x = Random.Range(-anchoNivel, anchoNivel);

        // 2. Elegir un prefab aleatorio del array (Normal, Rota, o Turbo)
        int randomIndex = Random.Range(0, plataformaPrefabs.Length);
        
        // 3. Instanciar
        Instantiate(plataformaPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        // 4. Incrementar la altura para la próxima plataforma
        alturaSiguientePlataforma += Random.Range(distanciaEntrePlataformas, distanciaEntrePlataformasA);
    }
}