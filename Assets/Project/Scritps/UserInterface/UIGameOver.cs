using System.Linq;
using UnityEngine;

public class UIGameOver : MonoBehaviour {

    private GameState _gameState;
    private RectTransform[] _children;

    private void Awake()
    {
        _children = gameObject.GetComponentsInChildren<RectTransform>().Where(rt => rt.gameObject != gameObject).ToArray();
        _gameState = FindObjectOfType<GameState>();
    }

    private void Start()
    {
        foreach (var child in _children)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_gameState.CanNotWin())
        {
            foreach (var child in _children)
            {
                //Game Over!
                child.gameObject.SetActive(true);
            }
        }
    }
}
