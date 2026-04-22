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
    }

    void Update()
    {
        if (cam == null || animator == null) return;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.3f, out hit, 50f))
        {
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