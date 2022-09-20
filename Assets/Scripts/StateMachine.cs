using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;

    [SerializeField] TextMeshProUGUI stateText;

    private void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
            StateText();
        }   
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    private void StateText()
    {
        stateText.text = currentState.name;
    }
}
