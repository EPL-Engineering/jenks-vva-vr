using System;
using System.Collections.Generic;
using Jenks.VVA;

namespace VVA_Controller
{
    public class ProtocolState
    {
        public List<TestSpecification> protocol = null;
        public int nextTest = 0;

        public ProtocolState() { }
        public ProtocolState(List<TestSpecification> tests)
        {
            protocol = tests;
        }

        public bool IsFinished { get { return nextTest >= protocol.Count; } }
        public TestSpecification CurrentTest { get { return IsFinished ? null : protocol[nextTest]; } }

        public void Advance()
        {
            nextTest++;
        }
    }
}