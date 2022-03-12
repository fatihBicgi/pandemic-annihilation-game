using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlev : MonoBehaviour
{
    // Start is called before the first frame update
    public void load1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
    public void load2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("a");
    }
    public void loadmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu 3D");
    }
}
