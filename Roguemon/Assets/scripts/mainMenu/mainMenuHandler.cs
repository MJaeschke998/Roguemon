using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuHandler : MonoBehaviour
{
public void StartGame() {
    SceneManager.LoadScene("mainGame");
}
public void Quit(){
    Application.Quit();
}
}
