using UnityEngine;

public class bg_changer : MonoBehaviour
{
    [Header("Configuración de Seguimiento")]
    public Transform objetivo; 
    public Vector3 offset = new Vector3(0, 0, 10); 
    
    [Header("Configuración de Sprites")]
    public Sprite[] backgrounds; 
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        if (backgrounds.Length > 0 && spriteRenderer != null)
        {
            spriteRenderer.sprite = backgrounds[0];
        }
    }

    void Update()
    {
        if (objetivo != null)
        {
            // Sigue la posición del objetivo más el offset
            transform.position = objetivo.position + offset;
        }
    }
    
    [ContextMenu("Change Background")]
    public void getRandomBackground()
    {
        if (backgrounds.Length == 0) return;
        
        int index = Random.Range(0, backgrounds.Length);
        spriteRenderer.sprite = backgrounds[index];
    }
    
    public void setTarget(Transform newTarget)
    {
        objetivo = newTarget;
    }
}