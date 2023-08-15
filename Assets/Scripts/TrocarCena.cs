using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrocarCena : MonoBehaviour
{   
    public Button botaoTrocarCena;
    public string nomeCenaParaTrocar;

    void Start()
    {
        botaoTrocarCena.onClick.AddListener(TrocarParaCena);
    }

    void TrocarParaCena()
    {
        SceneManager.LoadScene(nomeCenaParaTrocar);
        Time.timeScale = 1f;
    }

}