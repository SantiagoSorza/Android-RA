using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float velocidadRotacion = 90f;

    void Update()
    {
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
