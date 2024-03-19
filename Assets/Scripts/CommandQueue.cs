using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class CommandQueue : MonoBehaviour
{
    private static CommandQueue instance;

    public static CommandQueue Instance => instance;

    private void Awake()
    {
        instance = this;
    }

    // ---------------------------------------- ^ singleton stuff

    private Queue<Command> commandQueue = new Queue<Command>();

    public void EnqueueCommand(Command command)
    {
        commandQueue.Enqueue(command);
    }

    private void Update()
    {
        if(commandQueue.Count > 0)
        {
            var cmd = commandQueue.Dequeue();
            cmd.Execute();
        }
    }


}
