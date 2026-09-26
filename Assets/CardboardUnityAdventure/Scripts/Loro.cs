using System.Collections;
using UnityEngine;

public class Loro : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private string tipoQueAcepta = "Galleta";
    [SerializeField] private AudioClip sonidoComer;
    [SerializeField] private Transform posicionAlLadoDelJugador; // hijo vacío del Player, ej. "LoroSlot"
    [SerializeField] private float duracionAnimacionComer = 0.3f;

    private AudioSource audioSource;
    private bool yaAlimentado = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void OnPointerEnterXR() { }
    public void OnPointerExitXR() { }

    public void OnPointerClickXR()
    {
        if (yaAlimentado) return;

        GameObject item = GrabManager.Instance.heldItem;
        if (item == null) return;

        GrabObject grabObj = item.GetComponent<GrabObject>();
        if (grabObj == null || !grabObj.type.Equals(tipoQueAcepta)) return;

        // Es una galleta: se la comemos
        grabObj.Delete(); // la desactiva y libera el heldItem del GrabManager
        StartCoroutine(ComerYSeguir());
    }

    private IEnumerator ComerYSeguir()
    {
        yaAlimentado = true;

        if (sonidoComer != null)
            audioSource.PlayOneShot(sonidoComer);

        yield return new WaitForSeconds(duracionAnimacionComer);

        // A partir de acá, el loro se monta al lado del jugador para el resto de la partida
        if (posicionAlLadoDelJugador != null)
        {
            transform.SetParent(posicionAlLadoDelJugador, false);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
    }
}