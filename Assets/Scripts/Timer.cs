using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const float Delay = 0.5f;

    [SerializeField] private TMP_Text _text;

    private int _counter;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RestartCoroutine();
        }
    }

    private void RestartCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }
        else
        {
            _coroutine = StartCoroutine(LaunchTimer());
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }

    private IEnumerator LaunchTimer()
    {
        WaitForSeconds waitForSeconds = new(Delay);

        while (enabled)
        {
            _counter++;
            DisplayCountdown(_counter);

            yield return waitForSeconds;
        }
    }
}
