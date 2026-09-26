using UnityEngine;
using UnityEngine.Events;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    public int totalObjetos = 0;
    public int objetosRecolectados = 0;

    public UnityEvent<int, int> OnProgresoActualizado;
    public UnityEvent OnTodoRecolectado;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RegistrarObjeto()
    {
        totalObjetos++;
    }

    public void Recolectar(string nombreObjeto = "")
    {
        objetosRecolectados++;
        OnProgresoActualizado?.Invoke(objetosRecolectados, totalObjetos);

        if (objetosRecolectados >= totalObjetos)
        {
            OnTodoRecolectado?.Invoke();
        }
    }
}