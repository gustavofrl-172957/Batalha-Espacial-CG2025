using UnityEngine;
public class AutoDestroy : MonoBehaviour
{
    // O tempo deve ser igual ou um pouco maior que a duração da animação
    public float lifeDuration = 0.5f; 

    void Start()
    {
        // Pega a duração da animação e destroi o objeto depois
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            // Pega o tempo do primeiro clip de animação
            lifeDuration = anim.GetCurrentAnimatorStateInfo(0).length;
        }
        Destroy(gameObject, lifeDuration); 
    }
}