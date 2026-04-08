using UnityEngine;

public class GazeAnimation : MonoBehaviour
{
    private Camera cam;
    private Animator animator;

    public float tempoDeOlhar = 1.5f;
    private float contador;
    private bool jaAtivou = false;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator NÃO encontrado no objeto pai!");
        }
    }

    void Update()
    {
        if (jaAtivou || cam == null || animator == null) return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50f))
        {
            // Procura Animator no pai do objeto atingido
            Animator animHit = hit.transform.GetComponentInParent<Animator>();

            if (animHit == animator)
            {
                contador += Time.deltaTime;

                if (contador >= tempoDeOlhar)
                {
                    Debug.Log("GAZE COMPLETO ANIMAÇÃO ATIVADA");
                    animator.SetTrigger("PlayAnim");
                    jaAtivou = true;
                }
            }
            else
            {
                contador = 0f;
            }
        }
        else
        {
            contador = 0f;
        }
    }
}
