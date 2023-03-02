using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LoadingProgressBarAnimation : MonoBehaviour, IDisposable
{
    private VisualElement _root;
    private VisualElement _loadingProgressBar;
    private Label _loadingPercentageText;
    
    void Start()
    {
        //Grab a reference to the root element that is drawn
        _root = GetComponent<UIDocument>().rootVisualElement;
        //Search the root for the two dynamic elements that need to be animated
        _loadingProgressBar = _root.Q<VisualElement>("bar_Progress");
        _loadingPercentageText = _root.Q<Label>("txt_Percentage");
    }

    void Update()
    {
        var percent = (Time.realtimeSinceStartup * 10) % 100;

        _loadingPercentageText.text = percent.ToString("N0") + "%";
        //Grab the final width of the progress bar based on the parent and
        //remove 25px to account for margins
        float endWidth = _loadingProgressBar.parent.worldBound.width - 25;
        var style = _loadingProgressBar.style;
        style.width = Length.Percent(percent);
        // _loadingProgressBar.style = style;

    }

    private void ReleaseUnmanagedResources()
    {
        // TODO release unmanaged resources here
    }

    protected virtual void Dispose(bool disposing)
    {
        ReleaseUnmanagedResources();
        if (disposing)
        {
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~LoadingProgressBarAnimation()
    {
        Dispose(false);
    }
}
