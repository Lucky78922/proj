using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mover : MonoBehaviour {
    public void Move(int scene) => SceneManager.LoadScene(scene);
    public void Exit()=>Application.Quit();
}
