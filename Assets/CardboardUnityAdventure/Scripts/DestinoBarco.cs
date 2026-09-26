using UnityEngine;

public class DestinoBarco : MonoBehaviour
{
    public enum TipoDestino { CambiarEscena, DetenerBarco }

    [Header("Configuración")]
    public TipoDestino tipo;

    [Header("Referencias")]
    public MovimientoBarco barco;           // arrastrás el barco acá directo
    public CambiodeEscena cambiadorEscena;  // arrastrás el objeto que tiene ese script
    public int numeroEscena;                // solo si tipo = CambiarEscena

    private void OnTriggerEnter(Collider other)
    {
        // Verifica que quien entró sea el barco (o algo dentro del barco), comparando el componente
        MovimientoBarco barcoDetectado = other.GetComponent<MovimientoBarco>();
        if (barcoDetectado == null) barcoDetectado = other.GetComponentInParent<MovimientoBarco>();

        if (barcoDetectado == null || barcoDetectado != barco) return;

        switch (tipo)
        {
            case TipoDestino.CambiarEscena:
                cambiadorEscena.CambiarEscena(numeroEscena);
                break;

            case TipoDestino.DetenerBarco:
                barco.EstaControlando = false;
                barco.LlegoADestino = true;
                break;
        }
    }
}