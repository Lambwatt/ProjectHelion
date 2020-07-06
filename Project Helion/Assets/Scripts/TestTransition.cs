using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransition : MonoBehaviour
{
    public void RunTest()
    {
        Registrar.Instance.TransitionHandler.GoToScene(Scenes.TEST);
    }
}
