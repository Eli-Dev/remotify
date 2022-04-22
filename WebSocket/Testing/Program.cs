using Logic;
using NetFwTypeLib;
using System;
using System.Threading;
using WebApplication;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //addInboundFirewallRule();
            //addOutboundFirewallRule();
            Thread t = new Thread(Websocket.Start);
            t.Start();
            new Controller();
            //Console.WriteLine("Alo");
            Console.ReadKey();
        }

        private static void addInboundFirewallRule()
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;

            // Let's create a new rule
            INetFwRule2 inboundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            inboundRule.Enabled = true;
            //Allow through firewall
            inboundRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
            inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            //Using protocol TCP
            inboundRule.Protocol = 6; // TCP
                                      //Port 81
            inboundRule.LocalPorts = "5001";
            //Name of rule
            inboundRule.Name = "RemotifyIn";
            // ...//
            inboundRule.Profiles = currentProfiles;

            addFirewallRule(inboundRule);
        }

        private static void addOutboundFirewallRule()
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;


            // Let's create a new rule
            INetFwRule2 outBoundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            outBoundRule.Enabled = true;
            //Allow through firewall
            outBoundRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            outBoundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            //Using protocol TCP
            outBoundRule.Protocol = 6; // TCP
                                       //Port 81
            outBoundRule.LocalPorts = "5001";
            //Name of rule
            outBoundRule.Name = "RemotifyOut";
            // ...//
            outBoundRule.Profiles = currentProfiles;

            addFirewallRule(outBoundRule);
        }

        private static void addFirewallRule(INetFwRule2 rule)
        {

            // Now add the rule
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(rule);
        }
    }
}
