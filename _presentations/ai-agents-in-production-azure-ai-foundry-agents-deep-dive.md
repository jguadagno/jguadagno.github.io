---
title: "AI Agents in Production: Azure AI Foundry Agents Deep Dive"
isKeynote: false
isRetired: false
sourceUrl: https://github.com/jguadagno/ai-agents-in-production-azureai-foundry-agents-deep-dive
powerPointUrl: https://1drv.ms/p/c/406ee4c95978c038/IQRoAF4aE8IBR6rmKTIOJUtdAQZfuYRCWRru2kwwYOel628
youTubeId: 
youTubeCaption: 
sessionizeUrl: ai-agents-in-production-azure-ai-foundry-agents-de/183197
level: 200
links:
 - title: Azure AI Foundry documentation
   url: https://learn.microsoft.com/azure/ai-studio/
 - title: Microsoft Foundry SDK quickstart
   url: https://learn.microsoft.com/azure/ai-studio/quickstarts/
 - title: SDK samples on GitHub
   url: https://github.com/Azure/azure-sdk-for-net
 - title: Azure AI Foundry pricing
   url: https://azure.microsoft.com/pricing/
---
Chat completions are yesterday's news - the real power of large language models comes alive when you give them the ability to reason, plan, and take action. In this session, we go deep on Microsoft Foundry's Agents service and build autonomous AI agents that do real work. You will see how to create an agent, give it tools like Code Interpreter (for running Python and generating charts), File Search (for querying your documents at runtime), Bing Grounding (for live web results), and your own custom Azure Functions. We will build a multi-turn agent that maintains state across a conversation thread, then explore multi-agent orchestration patterns - routing agents, sequential pipelines, and human-in-the-loop escalation. Along the way, we will tackle the hard production questions: How do you manage thread lifecycles? What happens when a run stalls? How do you limit token budgets and tool call depth? How do you observe and debug agent behavior? You will leave with working code, architecture patterns, and the confidence to ship agents that your operations team won't hate.