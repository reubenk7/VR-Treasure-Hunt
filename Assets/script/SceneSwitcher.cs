using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void switchToSample()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void switchToLab()
    {
        SceneManager.LoadScene("ComputerLab");
    }

    public void switchToComBuild()
    {
        SceneManager.LoadScene("ImmserivePhoto");
    }

    public void switchToLoganPark()
    {
        SceneManager.LoadScene("loganpark");
    }

    public void switchToDigital()
    {
        SceneManager.LoadScene("3dmadescene");
    }
}
