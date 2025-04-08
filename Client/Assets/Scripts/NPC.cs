using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject ChatUI;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("@@@@");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("!!!!");
            ChatUI.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChatUI.gameObject.SetActive(false);
        }
    }
}
