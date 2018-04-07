using System;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ConnectButton : MonoBehaviour
    {
        public InputField NetAddressField;

        public void ConnectToServer()
        {
            Debug.Log(NetAddressField.text);
            //TODO при успешном подключении загружать главную сцену
            SceneManager.LoadScene("Main");
        }
    }
}