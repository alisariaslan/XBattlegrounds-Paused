using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    public GameObject tablet;
    public GameObject console;

    public TabletAnim tabletAnim;
    public Button enter;
    public InputField inputField;

    public PlayerControls player;
    public MovementController movementController;
    public bool ingame;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        ingame = FindObjectOfType<keep_alive>().ingame;


        if (Input.GetKeyDown(KeyCode.Tab) && ingame)
        {
            if (console.activeSelf)
                Console();
            Tablet();
        }
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (tablet.activeSelf)
                Tablet();
            Console();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (console.activeSelf)
            {
                enter.onClick.Invoke();
                inputField.ActivateInputField();
            }

        }


    }

    private void Tablet()
    {
        tablet.SetActive(!tablet.activeSelf);
        if (tablet.activeSelf)
        {
            player.paused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            tabletAnim.SetCursor();
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            player.paused = false;
        }
    }

    private void Console()
    {
        console.SetActive(!console.activeSelf);
        if (console.activeSelf)
        {
            if (player != null)
                player.paused = true;
            if (movementController != null)
                movementController.paused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
            inputField.ActivateInputField();
        }
        else
        {
            if (ingame)
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = false;
                if (player != null)
                    player.paused = false;
                if (movementController != null)
                    movementController.paused = false;
            }
        }
    }


}
