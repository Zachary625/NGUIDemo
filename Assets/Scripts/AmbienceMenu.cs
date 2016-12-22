using UnityEngine;
using System.Collections;

public class AmbienceMenu : MonoBehaviour {

    private bool _visible = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayTween_Show() {
        if (!this._visible) {
            this._visible = true;
            TweenPosition tweenPosition = this.GetComponent<TweenPosition>();
            TweenAlpha tweenAlpha = this.GetComponent<TweenAlpha>();

            this.GetComponent<TweenPosition>().PlayForward();
            this.GetComponent<TweenAlpha>().PlayForward();
        }
    }

    public void PlayTween_Hide() {
        if (this._visible)
        {
            this._visible = false;
            TweenPosition tweenPosition = this.GetComponent<TweenPosition>();
            TweenAlpha tweenAlpha = this.GetComponent<TweenAlpha>();

            this.GetComponent<TweenPosition>().PlayReverse();
            this.GetComponent<TweenAlpha>().PlayReverse();
        }
    }
}
