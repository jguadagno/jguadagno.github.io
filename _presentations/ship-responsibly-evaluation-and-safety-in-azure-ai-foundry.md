---
title: "Ship Responsibly: Evaluation and Safety in Azure AI Foundry"
isKeynote: false
isRetired: false
sourceUrl: 
powerPointUrl: 
youTubeId: 
youTubeCaption: 
sessionizeUrl: ship-responsibly-evaluation-and-safety-in-azure-ai/183198
level: 200
links:
  - title: Evaluation documentation
    url: https://learn.microsoft.com/azure/ai-studio/concepts/evaluation-approach-gen-ai
  - title: Content filtering
    url: https://learn.microsoft.com/azure/ai-studio/concepts/content-filtering
  - title: Responsible AI overview
    url: https://learn.microsoft.com/azure/ai-studio/concepts/responsible-ai
  - title: Foundry SDK samples
    url: https://github.com/Azure/azure-sdk-for-net
---
You have built an AI-powered application - now how do you know it actually works? Traditional software has unit tests and integration tests, but AI applications are probabilistic, context-dependent, and capable of producing harmful content. In this session, we tackle the hardest problem in AI engineering: measuring quality and ensuring safety before you ship. Using Azure AI Foundry's built-in evaluation framework, we will run quality evaluators (groundedness, relevance, coherence, fluency) and safety evaluators (violence, hate, self-harm, protected material, jailbreak detection) against a real application. You will see how to build test datasets, run evaluations locally and in the cloud, interpret scorecards, and integrate evaluation gates into your CI/CD pipeline so that a regression in quality or safety blocks deployment automatically. We will also cover Foundry's runtime content filters, the Risks and Safety monitoring dashboard, and how to build a responsible AI practice that goes beyond tooling - including human oversight, incident response, and transparency. Whether you are a developer, tech lead, or architect, you will leave with a practical playbook for shipping AI applications that your users can trust.