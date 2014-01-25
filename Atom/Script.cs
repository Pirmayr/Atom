using System;
using System.Windows.Forms;
using Atom;
using Nodes;

public class Script
{
    public static void Show(Host host)
    {
      host.TheForm.AddMsg(host.TheInterpreter.Values.Pop().Value);
    }
    
    public static void ShowLine(Host host)
    {
      host.TheForm.AddMsgLine(host.TheInterpreter.Values.Pop().Value);
    }
    
    public static void Modulo(Host host)
    {
      string tos0 = host.TheInterpreter.Values.Pop().Value;
      string tos1 = host.TheInterpreter.Values.Pop().Value;
      int result = int.Parse(tos1) % int.Parse(tos0);    
      host.TheInterpreter.Values.Push(NodesHelpers.NewNode(result.ToString()));
    }

    public static void Glue(Host host)
    {
      string tos0 = host.TheInterpreter.Values.Pop().Value;
      string tos1 = host.TheInterpreter.Values.Pop().Value;
      string result = tos1 + tos0;
      host.TheInterpreter.Values.Push(NodesHelpers.NewNode(result));
    }

    public static void Trim(Host host)
    {
      string tos = host.TheInterpreter.Values.Pop().Value;
      tos = tos.Trim();
      tos = tos.Replace("  ", " ");
      string result = tos;
      host.TheInterpreter.Values.Push(NodesHelpers.NewNode(result));
    }

    public static void Size(Host host)
    {
      INodeList tos = host.TheInterpreter.Values.Pop(1);
      host.TheInterpreter.Values.PushInt(tos[0].SafeList.Count);
    }
    
    public static void Item(Host host)
    {
      INodeList tos = host.TheInterpreter.Values.Pop(2);
      host.TheInterpreter.Values.Push(tos[1].SafeList.ItemAt(tos[0].GetValueInt()));
    }
    
    public static void Join(Host host)
    {
      INodeList tos = host.TheInterpreter.Values.Pop(2);
      host.TheInterpreter.Values.Push(tos[1].Added(tos[0].SafeList));    
    }
  }


