using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blip : MonoBehaviour
{
    [Header("Outline")]
    [SerializeField] private Image _blipOutlineImage;

    private Plane _blipPlane;

    private float _timeToEnabled = 2f;

    private Coroutine _timerCoroutine;

    private Radar _radar;

    private bool _isTracked;
    public Plane GetPlane { get { return _blipPlane; } }
    public bool IsTracked { get { return _isTracked; } }


    void Awake()
    {
        _radar = FindObjectOfType<Radar>();
        _blipOutlineImage.enabled = false;
    }

    private void OnMouseEnter()
    {
        _blipOutlineImage.enabled = true;
    }

    private void OnMouseDown()
    {
        _radar.GetWayInfo(this);
        _isTracked = true;
    }

    private void OnMouseExit()
    {
        _blipOutlineImage.enabled = false;
    }
    public void ActivateBlip()
    {
        gameObject.SetActive(true);

        if (_timerCoroutine != null)
        {
            StopCoroutine(_timerCoroutine);
        }

        _timerCoroutine = StartCoroutine(DisableAfterTime());
    }

    private IEnumerator DisableAfterTime()
    {
        yield return new WaitForSeconds(_timeToEnabled);
        gameObject.SetActive(false);
    }

    public void SetTimer(float value)
    {
        _timeToEnabled = value;
    }

    public void SetBlipPlane(Plane plane)
    {
        _blipPlane = plane;
    }


}
