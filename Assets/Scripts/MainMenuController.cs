using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    
    public int selectedCharacter;

    public void SelectPlayer1() {
        selectedCharacter = 0;
        Debug.Log(selectedCharacter);
        GameManager.characterIndex = selectedCharacter;
        SceneManager.LoadScene("GamePlay");
    }

    public void SelectPlayer2() {
        selectedCharacter = 1;
        Debug.Log(selectedCharacter);
        GameManager.characterIndex = selectedCharacter;
        SceneManager.LoadScene("GamePlay");
    }
}
