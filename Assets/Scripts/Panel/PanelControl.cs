using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelControl : MonoBehaviour
{
    public Text puntos, vidasT;
    int contador, vidas=5;

    private void Start()
    {
        puntos.text = contador.ToString();
        vidasT.text = "Vida= " + vidas;
        Time.timeScale = 0;
    }
    public void Continuar(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Vida()
    {
        vidas--;
        vidasT.text = "Vida= " + vidas;
        if (vidas <= 0) SceneManager.LoadScene(0);
    }

    public void Puntos(int a)
    {
        contador += a;
        puntos.text = contador.ToString();
    }
}
