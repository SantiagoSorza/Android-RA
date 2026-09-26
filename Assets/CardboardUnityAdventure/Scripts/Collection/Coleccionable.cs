using System.Collections;
using UnityEngine;

public class Coleccionable : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private string nombreObjeto = "Objeto";
    [SerializeField] private GameObject modeloVisual;
    [SerializeField] private float duracionRecoleccion = 0.4f;
    [SerializeField] private AudioClip sonidoRecoleccion;

    private bool yaRecolectado = false;

    private void Start()
    {
        CollectibleManager.Instance.RegistrarObjeto();
    }

    public void OnPointerEnterXR() { }
    public void OnPointerExitXR() { }

    public void OnPointerClickXR()
    {
        if (yaRecolectado) return;
        yaRecolectado = true;
        StartCoroutine(Recolectar());
    }

    private IEnumerator Recolectar()
    {
        if (sonidoRecoleccion != null)
            AudioSource.PlayClipAtPoint(sonidoRecoleccion, transform.position);

        float t = 0f;
        Vector3 escalaInicial = modeloVisual != null ? modeloVisual.transform.localScale : Vector3.one;

        while (t < duracionRecoleccion)
        {
            t += Time.deltaTime;
            float progreso = t / duracionRecoleccion;

            if (modeloVisual != null)
                modeloVisual.transform.localScale = Vector3.Lerp(escalaInicial, Vector3.zero, progreso);

            transform.position += Vector3.up * (Time.deltaTime * 1.5f);
            yield return null;
        }

        CollectibleManager.Instance.Recolectar(nombreObjeto);
        gameObject.SetActive(false);
    }
}