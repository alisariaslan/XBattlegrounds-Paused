using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class input_port_connect : MonoBehaviour
{
    public InputField input;
    // Start is called before the first frame update
    void Start()
    {
        input.text = PlayerPrefs.GetString("LastConnectedPort", "");
    }

    // Update is called once per frame
    public void SaveDatabase()
    {
        PlayerPrefs.SetString("LastConnectedPort", input.text);
    }
}
