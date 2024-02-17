
# Suggested Learning Resources

## Contents

- [How to Leverage LLMs for Building Various Copilot Applications](#how-to-leverage-llms-for-building-various-copilot-applications)
- [LLM](#llm)
- [App Development](#app-development)
- [Quality](#quality)
- [Introductory courses to Vector DBs](#introductory-courses-to-vector-dbs)
- [Additional resources](#additional-resources)


## How to Leverage LLMs for Building Various Copilot Applications

To effectively integrate Large Language Models (LLMs) into app development, it's crucial to have a solid understanding of LLMs. Therefore, this section presents a list of learning resources. For optimal learning, it is advised to pursue the courses in the sequence provided below.


- Base Model Knowledge: The LLM base models are trained on millions of data available publicly and hence can be used as-is for building copilots for many of the use cases. This is possible by the technique of prompt engineering – with simple prompts or with few shot learning (providing examples)
Few of the possibilities (but not limited to) of building your own copilots that can do:
    - Code generation:
        - Generate code snippets or complete functions based on natural language queries or specifications.
        - Provide general programming syntax and logic, while the user data can provide domain-specific details and preferences.
        - Check for time complexity of the code.
        - Generate documentation for the code.
    - Content creation: 
        - Create engaging and informative content for blogs, websites, social media, or newsletters based on keywords, topics, or prompts. 
        - Generate content with linguistic fluency and diversity, while the user can provide style, tone, and audience awareness.
    - Data analysis:
        - Execute data analysis tasks such as data cleaning, visualization, exploration, or modeling based on natural language commands or questions. 
        - Provide general statistical analysis and report generation from the structured data provided by the user along with suitable prompting.
    - Text mining:
        - Extract relevant entities, concepts, relations, or events from a given text or document, such as names, dates, locations, topics, sentiments, or opinions. 
    -	Text Categorization & Summarization:
        - Execute tasks like summarizing text data like reviews about products and services, categorization into different segments based on the description/text data associated and so on.
- LLM On/With your data
    1.	RAG pattern:
        - Push approach - [RAG Pattern](/rag.md)
        - Pull approach – [Using Function Calling](/Development.md#plugins-tools-and-functions)
    2.	Fine-tuning (To do)
        - Full finetuning
        - Parameter efficient Fine- tuning
    3.	Hybrid approach (RAG + Fine-tuning) (To do)

## LLM

- For an amazing introductory course on LLMs, check out the DeepLearning.AI course [Generative AI with Large Language Models (20+h) ![external link](/content/imgs/external_link.png)](https://www.coursera.org/learn/generative-ai-with-llms). This course provides a strong foundation in understanding LLMs, including the Attention Is All You Need algorithm, language model workings, embedding, and the challenges with Large Language Models. It also covers finetuning strategies and how smaller fine-tuned models can achieve comparable or even better results than large models.
    
    ![Attention Is All You Need algorithm](content/imgs/attention.png)
    *Attention Is All You Need algorithm*

    Course also dives into Generative AI project lifecycle.
    
    ![Generative AI project lifecycle](content/imgs/lifecycle.png)
    *Generative AI project lifecycle*

- If you prefer a shorter introduction, you can watch the [Intro to Large Language Models (1h) ![external link](/content/imgs/external_link.png)](https://www.youtube.com/watch?v=zjkBMFhNj_g) video.

## App Development

> DeepLearning.AI is often recomened in this section. DeepLearning.AI is led by a team of instructors from Stanford University and deeplearning.ai, offers a comprehensive platform for learning AI development. They provide a wide range of courses, specializations, and professional certificates.

- Prompt engineering refers to the practice of crafting and optimizing input prompts by selecting appropriate words, phrases, sentences, punctuation, and separator characters to effectively use LLMs for a wide variety of applications. In other words, prompt engineering is the art of communicating with an LLM.  Refer to these resources to learn more about prompt engineering:
    - [ChatGPT Prompt Engineering for Developers (2h) ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/chatgpt-prompt-eng)
    - [Prompt Engineering ![external link](/content/imgs/external_link.png)](https://platform.openai.com/docs/guides/prompt-engineering) article from OpenAI are recommended resources for learning prompting techniques.
- There are two main approaches to send prompts to LLM:
    - Leveraging API libraries
    - Using SDKs/Frameworks that utilize API libraries
    
    We will review API libs and SDKs/Frameworks later in this document but for now complete some of the following courses to get a better understanding how to send prompts to LLMs:

    - [LangChain for LLM Application Development (2h) ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/langchain/) provides insights into using LangChain for LLM development.
    - [LangChain Chat with Your Data (2h) ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/langchain-chat-with-your-data/) is a course that demonstrates the use of LangChain for the RAG pattern.
    - [How Business Thinkers Can Start Building AI Plugins With Semantic Kernel (2h) ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/microsoft-semantic-kernel/) introduces Semantic Kernel (SK) and provides guidance on building AI plugins with it.

### Quality.

Verifying the quality of responses generated by LLMs in applications is an emerging area in software development. The courses listed below offer valuable insights into this process:

- [Evaluating and Debugging Generative AI (2h) ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/evaluating-debugging-generative-ai) is a course that explains how to use LLM to validate responses.
- [Quality and Safety for LLM Applications (2h) ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/quality-safety-llm-applications/) another great quality and safety of outputs. 

### Introductory courses to Vector DBs.
- [Advanced Retrieval for AI with Chroma (2h) ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/advanced-retrieval-for-ai/)
- [Vector Databases: from Embeddings to Applications (2h) ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/vector-databases-embeddings-applications/) - utilizes Weaviate

For more great courses on LLMs, visit [DeepLearning.AI Short Courses ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/). DeepLearning.AI constantly adds new courses, so it is recommended to check back often. As of the beginning of 2024, DeepLearning.AI remains one of the foundational sources for learning about LLMs and app development leveraging LLMs.

### Additional resources

- [LangChain Course ![external link](/content/imgs/external_link.png)](https://www.youtube.com/playlist?list=PLqZXAkvF1bPNQER9mLmDbntNfSpzdDIU5): A comprehensive course exposing interesting patterns, although code samples could be outdated.
- [Develop Generative AI solutions with Azure OpenAI Service ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-gb/training/paths/develop-ai-solutions-azure-openai/): Light courses from Microsoft.
- Short but very saturated videos on Azure Open AI:
    - [Introduction to Azure OpenAI and Architecture Patterns ![external link](/content/imgs/external_link.png)](https://www.youtube.com/watch?v=TI85JJVPnrM)
    - [Azure OpenAI Chat With Your Data No Code Edition ![external link](/content/imgs/external_link.png)](https://www.youtube.com/watch?v=tFJNasjGM3E)