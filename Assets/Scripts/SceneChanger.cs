using UnityEngine;
using UnityEngine.SceneManagement; // Perlu di-import untuk mengakses SceneManager

public class SceneChanger : MonoBehaviour
{
    // Nama scene tujuan atau index scene tujuan (sesuaikan dengan Build Settings)
    public string sceneName; // Bisa juga menggunakan int sceneIndex;

    // Fungsi untuk mendeteksi tabrakan
    private void OnCollisionEnter2D(Collision2D collision) // atau OnTriggerEnter2D jika menggunakan trigger
    {
        // Periksa apakah karakter menabrak sesuatu dengan tag tertentu, misalnya "Target"
        if (collision.gameObject.tag == "changeScene")
        {
            // Pindah ke scene berikutnya menggunakan nama scene
            SceneManager.LoadScene(sceneName); // Atau SceneManager.LoadScene(sceneIndex); jika pakai index
        }
    }
}
