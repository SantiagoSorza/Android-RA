using UnityEngine;

public class Timon : MonoBehaviour
{
    public MovimientoBarco barco;

    // Se llama cuando el jugador empieza a mirar el timón
    public void OnPointerEnterXR()
    {
        // Opcional: acá podrías activar un highlight visual, sonido, etc.
    }

    // Se llama cuando el jugador deja de mirar el timón
    public void OnPointerExitXR()
    {
        // Opcional: apagar highlight, etc.
    }

    // Se llama cuando se completa el gaze (círculo lleno) o se presiona el trigger
    public void OnPointerClickXR()
    {
        ActivarTimon();
    }

    void ActivarTimon()
    {
        barco.EstaControlando = true;
    }
}