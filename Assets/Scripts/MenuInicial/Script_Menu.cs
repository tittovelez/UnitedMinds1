using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Script_Menu : MonoBehaviour
{
    public void EmpezarNivel(string NombreNivel)
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Application.Quit();

    }
}
