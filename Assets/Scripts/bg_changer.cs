using UnityEngine;

public class bg_changer : MonoBehaviour
{
    public Sprite[] backgrounds; 
    public SpriteRenderer spriteRenderer;
    
    void Update()
    {
        
    }
    
    void Start()
    {
        spriteRenderer.sprite = backgrounds[0];
    }
    
    [ContextMenu("Change Background")]
    public void getRandomBackground()
    {
        int index = Random.Range(0, backgrounds.Length);
        spriteRenderer.sprite = backgrounds[index];
    }
}
