using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatAction {
    public delegate void Action();

    float acTime = 0.0f;
    Action action;
    float cycle;

    public RepeatAction(float cycle, Action action) {
        this.action = action;
        this.cycle = cycle;

        acTime = cycle - 0.1f;
	}
	
	public void Update () {
        acTime += Time.deltaTime;

        if(acTime > cycle) {
            acTime -= cycle;

            action();
        }
	}
}
