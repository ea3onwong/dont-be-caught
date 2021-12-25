using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    
    public int selectedCharacter;

    public void SelectPlayer1() {
        selectedCharacter = 0;
        GameManager.characterIndex = selectedCharacter;
        SceneManager.LoadScene("GamePlayLevel1");
    }

    public void SelectPlayer2() {
        selectedCharacter = 1;
        GameManager.characterIndex = selectedCharacter;
        SceneManager.LoadScene("GamePlayLevel1");
    }
}
