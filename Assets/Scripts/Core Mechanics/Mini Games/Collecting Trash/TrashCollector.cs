using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    [Header("Trash Collector Settings")]
    [SerializeField] int maxTrash = 4;
    public int trashCollected;

    [Header("Trash Object Settings")]
    [SerializeField] Transform playerTransform;
    public GameObject trashPrefab;
    public List<GameObject> collectedTrash = new List<GameObject>();

    [Header("Trash Collector UI")]
    [SerializeField] GameObject pickupIcon;

    [Header("Burn Area Settings")]
    [SerializeField] Transform burnArea; // Tempat pembakaran sampah
    [SerializeField] float dropSpeed = 1f; // Kecepatan animasi drop

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trashCollected > 0 && Vector3.Distance(playerTransform.position, burnArea.position) < 2f) // Jarak dekat ke tempat pembakaran
        {
            DropTrash(); // Buang sampah jika dekat dengan tempat pembakaran
        }
    }

    void PickupTrash(GameObject trash)
    {
        if (Input.GetKeyDown(KeyCode.E) && trashCollected < maxTrash)
        {
            trashCollected++;

            // Set trash sebagai anak dari player
            trash.transform.SetParent(playerTransform);
            trash.transform.localPosition = Vector3.zero; // Letakkan di posisi player

            // Tambahkan ke list sampah yang diambil
            collectedTrash.Add(trash);

            Debug.Log("Sampah diambil: " + trashCollected);
        }
    }

    void DropTrash()
    {
        if (collectedTrash.Count > 0)
        {
            GameObject trashToDrop = collectedTrash[0]; // Sampah yang akan dibuang

            // Lepaskan dari player
            trashToDrop.transform.SetParent(null);

            // Animasi drop ke tempat pembakaran menggunakan LeanTween
            LeanTween.move(trashToDrop, burnArea.position, dropSpeed).setOnComplete(() =>
            {
                Destroy(trashToDrop); // Hancurkan objek setelah sampai di tempat pembakaran
                collectedTrash.RemoveAt(0); // Hapus dari list
                trashCollected--;

                Debug.Log("Sampah dibuang, sisa: " + trashCollected);
            });
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            if (trashCollected < maxTrash)
            {
                PickupTrash(other.gameObject);
            }

            if (trashCollected == maxTrash)
            {
                Debug.Log("Sampah penuh, segera buang di tempat pembakaran!");
            }
        }
    }
}
