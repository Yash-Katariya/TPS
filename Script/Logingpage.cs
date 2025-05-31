using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logingpage : MonoBehaviour
{
    public GameObject Logo, Lobby;

    public void Start() 
    {
        StartCoroutine(MovetoLoding());
    }
    public IEnumerator MovetoLoding()
    {
        yield return new WaitForSeconds(4f);
        Logo.SetActive(false);
        Lobby.SetActive(true);
    }
    public void Nextpage()
    { 
        SceneManager.LoadScene("SimplyUP"); 
    }
}
