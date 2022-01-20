using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="AI/State")]
public class State : ScriptableObject
{
    public Act[] acts;
    public Transition[] transitions;

    public void UpdateState(EnemyMovement movement)
    {
        DoAction(movement);
        CheckTransition(movement);
    }
    public void DoAction(EnemyMovement movement)
    {
        foreach(Act act in acts)
        {
            act.Action(movement);
        }
    }
    public void CheckTransition(EnemyMovement movement)
    {
        foreach(Transition transition in transitions)
        {
            bool decided = transition.decide.Decided(movement);
            if (decided)
            {
                movement.TransitionToState(transition.trueS);
            }
            else
            {
                movement.TransitionToState(transition.falseS);
            }
        }
    }
}

[System.Serializable]
public class Transition
{
    public Decide decide;
    public State trueS;
    public State falseS;
}