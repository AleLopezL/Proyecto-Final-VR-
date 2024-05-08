using UnityEngine;
using UnityEngine.UI;
public class SettingsController : MonoBehaviour
{
    // Referencia al slider del volumen
    [SerializeField] Slider slider;

    [SerializeField] Toggle toggle;// Referencia al AudioSource con la música
    [SerializeField] AudioSource audioSource;
    // Método para cerrar el juego
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN
 Application.Quit();
#endif

    }

    void Start()
    { // Método Start que cargará la configuración existente
      // Recupera la configuración del volumen (si existe) o utiliza un valor predeterminado
        float savedVolume = PlayerPrefs.GetFloat("BackgroundMusicVolume", 0.5f);
        // Recupera la configuración del mute (si existe) o utiliza un valor predeterminado
        // En PlayerPrefs no se pueden guardar Booleans, por eso se usa Integer (0-1)
        int savedMute = PlayerPrefs.GetInt("BackgroundMusicMute", 0);
        LoadVolume(savedVolume); // Configuramos el volumen cargado
        LoadMute(savedMute); // Configuramos el estado del muteo cargado
    }
    void LoadVolume(float volume)
    { // Método para configurar un volumen específico en el Slider
        slider.value = volume; // Configuramos el Slider como corresponda
        audioSource.volume = volume; // Configuramos el AudioSource como corresponda
    }
    void LoadMute(int mute)
    { // Método para configurar el estado del Mute
        toggle.isOn = (mute == 1); // Configuramos el Toggle como corresponda
        audioSource.mute = !(mute == 1); // Configuramos el AudioSource como corresponda
    }

    public void ChangeVolume()
        {
            // Configuramos el volumen con el valor del slider
            audioSource.volume = slider.value;
        PlayerPrefs.SetFloat("BackgroundMusicVolume", audioSource.volume);
    }
        // Referencia al toggle que mutea la música
        // Metodo para mutear la música en base al toggle. Se llama
        // desde OnValueChanged() del GameObject con el Toggle
        public void MuteMusic()
        {
            // Si el toggle está activado la música se escuchará
            audioSource.mute = !toggle.isOn;
        PlayerPrefs.SetInt("BackgroundMusicMute", audioSource.mute == true ? 0 : 1);

    }
    public void SaveSettings()
    { // Metodo para guardar los PlayerPrefs
        PlayerPrefs.Save(); // Guarda los PlayerPrefs
    }

}