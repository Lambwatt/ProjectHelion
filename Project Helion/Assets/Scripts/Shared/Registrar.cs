using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Registrar
{
    private static Registrar registrar;

    public static Registrar Instance
    {
        get
        {
            if (registrar == null)
            {
                registrar = new Registrar();
            }
            return registrar;
        }

        private set { }
    }

    private Registrar()
    {

    }

    private TransitionHandler transitionhandler;
    public TransitionHandler TransitionHandler
    {
        get
        {
            if (transitionhandler == null)
            {
                DisplayRegistrarError(NotFoundError, "TransitionHandler");
            }
            return transitionhandler;
        }

        set
        {
            if (transitionhandler == null)
            {
                transitionhandler = value;
            }
            else
            {
                DisplayRegistrarError(DuplicateError, "TransitionHandler");
            }
        }
    }

    private void DisplayRegistrarError(string template, string variable)
    {
        Debug.LogErrorFormat(template, variable);
    }

    private const string NotFoundError = "REGISTRAR ERROR: {0} not found";
    private const string DuplicateError = "REGISTRAR ERROR: {0} already registered";
}
