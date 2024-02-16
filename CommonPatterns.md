# Common Patterns

## Contents

- [Conversational Bot](#conversational-bot)
- [Process Automation](#process-automation)
- [Decision Tree or Flow Orchestration](#decisigion-tree-or-flow-orchestraction)

The terms Copilot, Bot, or Virtual Assistant are often used interchangeably to refer to assistance that relies on Large Language Models (LLMs). This assistance can have a user interface (UI) or voice interface, or it could be invisible as part of background processes.

Here are common patterns that ISVs and Startups are using with LLMs:

## Conversational Bot

Conversational bots often utilize LLMs to interact with end users. These bots receive user queries and generate responses using LLMs. However, LLMs are not domain-specific by default. To make LLMs domain-specific, developers employ the [RAG pattern](#rag-pattern).  Addutionally to RAG pattern developerd will also need to develop bot.  Bot could be developed usign [Bot Framework SDK ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/azure/bot-service/bot-service-overview?view=azure-bot-service-4.0).

As an alternative, developers can deliver conversational bot with no-code/low-code approach using [Microsoft Copilot Studio](#microsoft-copilot-studio---no-code--low-code-development).

## Process Automation

LLMs are being utilized in tasks traditionally performed by humans. For instance, in recruitment agencies, recruiters analyze job descriptions and resumes to match candidates with suitable roles. Automating this process has been challenging for app developers, but with the help of LLMs, it becomes much easier. Here's a possible solution: 
1. Extract key characteristics from job descriptions using LLMs.
2. Use LLMs to scan resumes and identify the best fit for a role based on those key characteristics.

The same approach can be applied to other processes, such as checking if documents meet specific requirements or policies.

For more information on how to implement these scenarios, please refer to the [SDKs / Frameworks](#sdks--frameworks) section and the [Orchestration / Agents](#orchestration--agents) section later in this document.

## Decisigion Tree or Flow Orchestraction

In call center solutions, Large Language Models (LLMs) can be utilized to determine the intent of customer queries. This intent can then be used to route the call to the appropriate agent or flow. LLMs can also generate responses to customers. If a customer wants to execute an action, the LLM can collect the necessary details and call a corresponding function.  Similarly as in Process Automation scenario, this can be implemented with [SDKs / Frameworks](#sdks--frameworks) and [Orchestration / Agents](#orchestration--agents).

For more detailed information on Call Center, Support, and Process Automation, you can refer to the [CoE.ContentPack.CallCenter ![external link](/content/imgs/external_link.png)](https://github.com/RobertEichenseer/CoE.ContentPack.CallCenter) repository.