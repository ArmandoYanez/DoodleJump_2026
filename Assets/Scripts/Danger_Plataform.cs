using UnityEngine;

public class Danger_Plataform : MonoBehaviour
{
    public Animator animation; 
    
    public void startBreaking()
    {
        animation.Play("breaking");
    }
}
