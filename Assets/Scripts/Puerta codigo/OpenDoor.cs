using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    private Animator anim;
    public bool IsAtDoor = false;
    private bool isDoorOpen = false;

    [SerializeField] private TextMeshProUGUI CodeText;
    private string codeTextValue = "";
    public string safeCode;
    public GameObject CodePanel;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CodeText.text = codeTextValue;

        // Comprobar si el código es correcto
        if (codeTextValue == safeCode && !isDoorOpen)
        {
            anim.SetTrigger("OpenDoor");
            CodePanel.SetActive(false);
            isDoorOpen = true;
        }

        // Reiniciar código si excede la longitud permitida
        if (codeTextValue.Length > 4)
        {
            Debug.Log("Código inválido, reiniciando...");
            codeTextValue = "";
        }

        // Abrir o cerrar el panel de código
        if (Input.GetKeyDown(KeyCode.E) && IsAtDoor)
        {
            CodePanel.SetActive(!CodePanel.activeSelf);
        }

        // Capturar la entrada del teclado para añadir dígitos
        if (CodePanel.activeInHierarchy)
        {
            for (int i = 0; i <= 9; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha0 + i) || Input.GetKeyDown(KeyCode.Keypad0 + i))
                {
                    AddDigit(i.ToString());
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsAtDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsAtDoor = false;
            CodePanel.SetActive(false);
        }
    }

    public void AddDigit(string digit)
    {
        if (codeTextValue.Length < 4)
        {
            codeTextValue += digit;
        }
        else
        {
            Debug.Log("No puedes añadir más dígitos.");
        }
    }
}

