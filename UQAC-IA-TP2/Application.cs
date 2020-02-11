﻿using System.Collections.Generic;
using System.Threading;
using UQAC_TP1_IA.core;
using UQAC_TP1_IA.core.functions;
using UQAC_TP1_IA.mansion;


namespace UQAC_IA_TP2
{
    /// <summary>
    /// Classes tests pour créer l'environnement et l'agent, démarrer leurs processus dans des thread.
    /// C'est ici qu'on donne la fonction d'exploration souhaitée à l'agent.
    ///
    /// On démarre aussi un 3ème thread pour le rendu
    /// </summary>
    internal static class Application
    {
        private static void Main(string[] args)
        {
            var mansionEnv = new MansionEnv();
            var agentGoal = (MansionPercept)mansionEnv.Observe();
            var agent = new MansionAgent(new Sensor(mansionEnv), new Effector(mansionEnv), new BreadthFirstSearch(), new MansionState(agentGoal));
            mansionEnv.SetAgent(agent, new Position(0, 0));


            var envRef = new ThreadStart(mansionEnv.Run);
            var envThread = new Thread(envRef);
            envThread.Start();

            var initialAgentState = new MansionState(new MansionPercept(new Position(0, 0)));
            var agentRef = new ThreadStart(() => agent.Run(initialAgentState));
            var agentThread = new Thread(agentRef);
            agentThread.Start();


            var render = new MansionConsoleRender(mansionEnv, agent);
            var renderRef = new ThreadStart(render.Process);
            var renderThread = new Thread(renderRef);
            renderThread.Start();
        }

    }
}