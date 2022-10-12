using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR // Adds the UnityEditor namespace if in the Unity editor.
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    /* Properties */
    public ColorPicker ColorPicker;


    /* Methods */
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
    }

    // Transitions to the main scene.
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    // Quits the game.
    public void Exit()
    {
#if UNITY_EDITOR // Quits the game in the Unity editor.
        EditorApplication.ExitPlaymode();
#else // Quites the game in any built version.
        Application.Quit();
#endif
    }
}
