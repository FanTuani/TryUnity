using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

public class ModsManager : MonoBehaviour {
    public static ModsManager instance;
    private object instanceDll;

    private void Start() {
        instance = this;

        string modName = "MyMod";
        string dllPath = Path.Combine(Application.persistentDataPath, "mods/" + modName + ".dll");
        Assembly assembly = Assembly.LoadFrom(dllPath);

        Type typeToInstantiate = assembly.GetType(modName + ".RiceMod");
        instanceDll = Activator.CreateInstance(typeToInstantiate);
        MethodInfo methodInfo = instanceDll.GetType().GetMethod("onEnable");

        if (methodInfo != null) {
            methodInfo.Invoke(instanceDll, null);
        } else {
            Debug.Log("INVALID MOD METHOD");
        }
    }

    private void Update() {
        MethodInfo methodInfo = instanceDll.GetType().GetMethod("update");
        methodInfo?.Invoke(instanceDll, null);
    }
}