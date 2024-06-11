using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager1 : MonoBehaviour
{
    [SerializeField] AudioSource musica;
    [SerializeField] AudioSource SFX;
    [SerializeField] int canEscenas;

    public AudioClip background;
    public static AudioManager1 instance;

    private int scenesPassed = 0; // Contador de escenas pasadas

    private void Awake() //aplicamos patrón de diseño singleton
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        musica.clip = background;
        musica.Play();
    }

    private void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    // Método para incrementar el contador de escenas pasadas
    public void IncrementScenesPassed()
    {
        scenesPassed++;

        // Si han pasado dos escenas, destruye este objeto
        if (scenesPassed >= canEscenas)
        {
            Destroy(gameObject);
        }
    }

    // Suscribirse al evento de carga de escena
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Desuscribirse al evento de carga de escena
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Método para manejar la carga de escenas
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Incrementar el contador de escenas pasadas cada vez que se carga una nueva escena
        IncrementScenesPassed();
    }
}
