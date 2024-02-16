
#  RAG pattern

## Contents

- [RAG stages](#rag-stages)
- [Loading](#loading)
- [Chunking / Splitting](#chunking--splitting)
- [Embedding and Storage to Vector DB](#embedding-and-storage-to-vector-db)
- [Retrieval](#retrieval)
- [Prompting](#prompting)

The RAG (Retrieval-Augmented Generation) pattern used with Large Language Models (LLMs) like GPT-3 is a machine learning approach that enhances the capabilities of generative models by combining them with retrieval-based models. This technique allows the LLM to access a broader range of information than what is contained in its training data, improving its performance in tasks that require specific, detailed, or up-to-date knowledge.

> GraphRAG is an advanced implementation of RAG that utilizes LLM-generated knowledge graphs to enhance question-and-answer performance during document analysis of complex information. To learn more about GraphRAG, refer to the [GraphRAG: Unlocking LLM discovery on narrative private data article ![external link](/content/imgs/external_link.png)](https://www.microsoft.com/en-us/research/blog/graphrag-unlocking-llm-discovery-on-narrative-private-data/).


[LangChain Chat With Your Data ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/langchain-chat-with-your-data) is a course that covers loading, chunking, and retrieval tactics used in RAG pattern leveraging LangChain.  The article [Advanced RAG: Small to Big Retrieval ![external link](/content/imgs/external_link.png)](https://towardsdatascience.com/advanced-rag-01-small-to-big-retrieval-172181b396d4) discusses Child-Parent Recursive Retriever and Sentence Window Retrieval with LlamaIndex. It also explores retrieval strategies such as Child to Parent and Window.  Semantic Kernel, combined with [Kernel Memory][def], can be utilized to implement the Retrieval-Augmented Generation (RAG) pattern.

When implementing the RAG pattern, it is important to use tools that you are familiar with for troubleshooting and debugging. Latency issues may arise at different stages of the pattern, requiring you to check logs for the Vector DB, LLM provider, and the SDK/Framework being used. Monitoring the performance of the RAG pattern is also crucial. This includes tracking the number of requests to each component (LLM provider, Vector DB, and SDK/Framework), as well as monitoring latency and cost.


## RAG stages

![rag](content/imgs/rag.png)

## 1. Loading

Loading is the initial stage in the RAG pattern, where data/text is obtained from various sources and formats before it is chunked and stored in a Vector DB.

LangChain provides loading capabilities from different sources and formats. Initially, Semantic Kernel had this feature, but it was later extracted to [Kernel Memory ![external link](/content/imgs/external_link.png)](https://github.com/microsoft/kernel-memory).

## 2. Chunking / Splitting
Automatic chunking is challenging when dealing with documents of different formats. Some customers have manually converted important PDFs to text and then chunked them to achieve better retrieval and completion results.

> Chunking is a crucial stage in the RAG pattern. It involves considering not only the size of the chunk but also its content. For example, if a document has 100 pages and only 1 paragraph is relevant to the question, it should be chunked in a way that separates the relevant paragraph into its own chunk. This allows for specific retrieval and prompt generation.

The quality of retrieval heavily relies on the quality of chunking. There is ongoing experimentation to achieve optimal and intelligent chunking.

## 3. Embedding and Storage to Vector DB

Embeding data and storing to vector DB is the next stage in the RAG pattern.  Some Vector DBs automatically generate embeddings as you save data. For more information, refer to the [Weaviate DB Course ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/vector-databases-embeddings-applications).

To ensure optimal retrieval and completion results, it is crucial to use the same model for creating embeddings of both chunks and questions. However, organizations may face challenges if the original embedding model becomes outdated or unavailable. To address this, consider the following options:

- Choose an embedding model with a distant deprecation date.
- Save the raw text of chunks along with their vectors, allowing for regeneration of embeddings using a newer model if necessary (although this may increase costs).
- Download the embedding model and host it on your own infrastructure, ensuring continued use even after deprecation (but incurring additional costs).

## 4. Retrieval

There are different strategies for retrieval. Some DBs provide configurable hybrid retrieval strategies. The retrieval practices are evolving, and we see that VectorDBs are taking ownership over this stage as it makes sense to filter data as close to the data source as possible. They are adding more and more features to support different retrieval strategies.  Retrieval is also an active space for research and development.


Here are some resources for advanced retrieval tactics:

- [Advanced Retrieval tactics using LlamaIndex ![external link](/content/imgs/external_link.png)](https://towardsdatascience.com/advanced-rag-01-small-to-big-retrieval-172181b396d4).  Article Discusses "Smaller Child Chunks Referring to Bigger Parent Chunks" and "Sentence Window Retrieval" taktics.
- [Advanced Retrieval for AI with Chroma and OpenAI SDK ![external link](/content/imgs/external_link.png)](https://learn.deeplearning.ai/advanced-retrieval-for-ai).  This course covers the [Query Expansion ![external link](/content/imgs/external_link.png)](https://arxiv.org/abs/2305.03653) and Re-ranking strategies to improve retrieval results:
    - Advanced Retrieval strategy: Query Expansion by Prompting Large Language Models     
    [<img src="content/imgs/QueryExpansion.png" width="250">](content/imgs/QueryExpansion.png)

    - Advanced Retrieval strategy: Query Expansion by Prompting Large Language Models     
    [<img src="content/imgs/QueryExpansionWithMultp.png" width="250">](content/imgs/QueryExpansionWithMultp.png)

    - Re-Ranking     
    [<img src="content/imgs/ReRanking.png" width="250">](content/imgs/ReRanking.png)
- LangChain has also implemented multiple [retrieval strategies ![external link](/content/imgs/external_link.png)](https://python.langchain.com/docs/modules/data_connection/retrievers/).


**Choice of Search types in RAG:**

The choice of the search types – **Text, Vector search** or **Hybrid Search** will depend on the use case.

- **Text Search:** Also known as keyword search where search is executed by matching keywords. The scoring is mostly done using BM25similarity which is based on TF-IDF (Term Frequency-Inverse Document Frequency and ranking by popular algorithm, BM25.
    
    This type of search is quite useful where:

    1. Exact keyword matching is required.
    2. [proximity search ![external link](/content/imgs/external_link.png)](https://en.wikipedia.org/wiki/Proximity_search_(text)) where documents are searched in which the keyword occur within a specified distance with another keyword irrespective of the order.

- **Vector Search:** Vector search involves encoding data and search queries as numerical vectors and using geometric or algebraic operations to determine similarity. It allows for semantic search by finding the closest data vectors to a query vector in a high-dimensional space, using measures like cosine similarity.
    
    This is useful where:

    1. Retrieval of relevant results based on meaning and context is required e.g. In the case of natural language processing, recommendation systems etc.
    2. Can handle situations where multiple forms of data like text, image and audio must be interpreted and then retrieve information. E.g.: retrieval of text and images in a search query.

- **Hybrid Search:** Hybrid search allows you to take advantage of multiple scoring algorithms such as BM25 and ANN vector similarity so you can get the benefits of both keyword search and semantic search.
    
    This type of search is useful in situations where the different scenarios mentioned in Text Search and Vector Search are required together.

## 5. Prompting

For a comprehensive list of strategies and tactics for prompting, you can refer to the [Prompt Engineering by OpenAI ![external link](/content/imgs/external_link.png)](https://platform.openai.com/docs/guides/prompt-engineering) guide. Additionally, you can find a compilation of prompting techniques in one place at the [Prompt Engineering Guide ![external link](/content/imgs/external_link.png)](https://www.promptingguide.ai/).
