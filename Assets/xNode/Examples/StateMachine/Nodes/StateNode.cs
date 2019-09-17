﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XNode.Examples.StateGraph {
	public class StateNode : Node {

		[Input] public Empty enter;
		[Output] public Empty exit;

        [TextArea] public string text;

        public void MoveNext() {
			StateGraph fmGraph = graph as StateGraph;

			if (fmGraph.current != this) {
				Debug.LogWarning("Node isn't active");
				return;
			}

			NodePort exitPort = GetOutputPort("exit");

			if (!exitPort.IsConnected) {
				Debug.LogWarning("Node isn't connected");
				return;
			}

			StateNode node = exitPort.Connection.node as StateNode;
			node.OnEnter();
		}

		public void OnEnter() {
			StateGraph fmGraph = graph as StateGraph;
			fmGraph.current = this;
		}

		// We don't care about the return value of the ports. Just return null to stop the console spam.
		public override object GetValue(NodePort port) {
			return null;
		}

		[Serializable]
		public class Empty { }
	}
}