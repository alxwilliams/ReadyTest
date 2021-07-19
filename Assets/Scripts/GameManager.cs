using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioManager _audio;
    [SerializeField] private GameObject _winText;
    private static GameManager sInstance = null;
    private int solvedPieces = 0;

    public static GameManager Instance
    {
        get => sInstance;
    }

    public void PlaySound(string name)
    {
        _audio.PlaySound(name, .5f);
    }

    private void Awake()
    {
        if(sInstance == null)
        {
            sInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void WinGame()
    {
        PlaySound("success");
        _winText.SetActive(true);
    }

    public void AddNewPiece()
    {
        solvedPieces++;

        if (solvedPieces >= 16)
            WinGame();
        else
            PlaySound("audio_correct");
    }
}
