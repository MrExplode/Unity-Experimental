using System.Linq;
using UnityEngine;

public class UIGameOver : MonoBehaviour {

    private Animator _animator;
    private RectTransform[] _children;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _children = gameObject.GetComponentsInChildren<RectTransform>().Where(rt => rt.gameObject != gameObject).ToArray();
    }

    private void Start()
    {
        foreach (var child in _children)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        foreach (var child in _children)
        {
            //Game Over!
            child.gameObject.SetActive(true);
        }

        _animator.SetTrigger("GameOver");
    }
}
