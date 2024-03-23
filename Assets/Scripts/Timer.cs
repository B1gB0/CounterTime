using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    private const float Delay = 0.5f;

    [SerializeField] private TMP_Text _text;

    private bool _isWork = false;
    private int _counter;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isWork = !_isWork;
            OnChangeTime();
        }
    }

    private void OnChangeTime()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(LaunchTimer());
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }

    private IEnumerator LaunchTimer()
    {
        WaitForSeconds waitForSeconds = new(Delay);

        while (_isWork)
        {
            _counter++;
            DisplayCountdown(_counter);

            yield return waitForSeconds;
        }
    }
}
