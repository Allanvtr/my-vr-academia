using UnityEngine;

public class GazeAnimation : MonoBehaviour
{
    public Camera cam;
    private Animator animator;

    public float tempoDeOlhar = 1.5f;
    private float contador;
    private bool jaAtivou = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator não encontrado!");
        }
        else
        {
            Debug.Log("Animator encontrado: " + animator.name);
        }
        if (cam == null)
        {
            Debug.LogError("Camera não iniciada");
        }
        else
        {
            Debug.LogError("Camera iniciada");
        }
    }

    void Update()
    {
        Debug.Log("Update");

        if (cam == null || animator == null) return;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.SphereCast(ray, 1f, out hit, 500f))
        {
            Debug.Log($"Acertou: {hit.collider.name} | Tag: {hit.collider.tag}");

            if (hit.transform.GetComponentInParent<GazeAnimation>() == this)
            {
                contador += Time.deltaTime;

                if (contador >= tempoDeOlhar)
                {
                    if (!jaAtivou)
                    {
                        animator.SetTrigger("PlayAnim");
                        jaAtivou = true;
                        contador = 0;
                    }
                    else
                    {
                        animator.SetTrigger("BaixarMao");
                        jaAtivou = false;
                    }
                }
            }
            else
            {
                contador = Mathf.Max(contador - Time.deltaTime, 0f);
            }
        }
        else
        {
            contador = Mathf.Max(contador - Time.deltaTime, 0f);
        }
    }
}