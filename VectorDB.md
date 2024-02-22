

# Vector DB

Most applications are built on traditional databases (relational databases) and with the emergence of big data, a new set of databases emerged which were classified as NoSql databases. With the boom in GenAI and LLMs, another kind of database gained popularity – vector databases.

A vector database is a database which is optimized for storing and querying high dimensional vector data. Vectors, in this context, are arrays of numbers that represent various forms of data like text, images etc. in a high-dimensional space. This makes vector databases extremely useful handling unstructured data for applications that require similarity-searches, recommendation systems, natural language processing tasks etc. These databases are also optimized for computationally intensive tasks. Vector databases are commonly used for RAG pattern and Semantic Caching.

> **Semantic caching** in app development is a technique where data is stored in a cache based on the semantics, or meaning, of the queries rather than the exact query text or results. This allows for more efficient use of cache space and quicker response times, as the cache can serve results for queries that are similar in meaning, even if they are not identical in form.

There are three major steps involved in a vector database for optimization and faster query retrievals: **Indexing, Querying** and **Postprocessing**

1. **Indexing**:
    1. **Flat** :
        - **Pros** : Accurate Search results
        - **Cons** : Exhaustive search, Suitable for relatively small datasets. e.g.: Linear search Algorithm
    1. **Approximate Nearest Neighbors:**

        The vector database indexes vectors using Approximate Nearest Neighbor Algorithms. Approximate nearest neighbor algorithms can be broadly split into trees, hashes, graphs, and quantization based. There can be indexing by combining some of these.
        1. **Trees** : One of the popular implementations is [Annoy ![external link](/content/imgs/external_link.png)](https://github.com/spotify/annoy).
            - **Pros** : Simple, Fast, and Scalable.
            - **Cons** : might not work well with high dimensional data as the tree becomes too deep and data will become sparse.
        1. **Hashes** : e.g., Locality Sensitive Hashing (LSH) indexes.
            - **Pros** : Memory efficient, can handle high dimensional data
            - **Cons** : have low recall value, and high number of false positives
        1. **Graphs** : e.g., Hierarchical Navigable Small Worlds Indexes
            - **Pros** : Fast and Accurate
            - **Cons** : Memory intensive and requires careful tuning of graph parameters.
        1. **Cluster:** e.g. Product Quantization
            - **Pros:** memory efficient, scalable
            - **Cons:** low accuracy, high computation cost, sensitive to the choice of cluster
1. **Querying**
    
    Querying in vector databases is the process of finding the most similar indexed vectors to a given indexed query vector in a high-dimensional space.
1. **Post-Processing**
    
    This is an optional step that can be used to improve the accuracy and relevance of the results retrieved after querying. It might involve re-ranking, filtering, or aggregating the nearest neighbors that are retrieved by indexing and searching methods.

Let us evaluate some popular vector DBs which will help in choosing the right vector database to suit the use case requirements.

1. **Pinecone:** available as cloud service. Supports Python, JavaScript/TypeScript, Rest API
    1. Query Performance:Proper [choice of the pod type and size ![external link](/content/imgs/external_link.png)](https://docs.pinecone.io/docs/choosing-index-type-and-size) and replicas are a major factor which determines the query performance factors like QPS and Latency.
    2. [Scalability ![external link](/content/imgs/external_link.png)](https://docs.pinecone.io/docs/scaling-indexes): Vertical scaling and horizontal scaling supported.
    3. [Multitenancy ![external link](/content/imgs/external_link.png)](https://docs.pinecone.io/docs/multitenancy) : describes keeping sets of vectors separate within a Pinecone index.
    4. Index Types: Graph based
    5. Storage: supports [S3 and GCS ![external link](/content/imgs/external_link.png)](https://docs.pinecone.io/docs/creating-datasets)
    6. [Distributed Architecture and Replica support ![external link](/content/imgs/external_link.png)](https://docs.pinecone.io/docs/architecture) ensuring reliability and resiliency.
1. **Weaviate:** Available as Serverless (cloud services), Docker, Kubernetes and Embedded Weaviate. SDK support is available for Python, JavaScript, Go, Java & Curl
    1. Query Performance: Fast queries; [benchmarking on ANN latencies and throughput ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/benchmarks) is available.
    2. [Scalability ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/concepts/cluster): Horizonal scaling supported
    3. [Search ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/search) types: Vector Search (Semantic), Scalar (text) and hybrid of vector and scalar, Image Search
    4. [Storage ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/concepts/storage): Kubernetes based deployment – [requires persistent volume ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/configuration/persistence#kubernetes).
    5. Replication: disabled by default, but [can be configured ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/configuration/replication) to increase availability and read throughput and for zero-downtime upgrades.
    6. [Multitenancy ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/manage-data/multi-tenancy): can be enabled.
    7. [Backups ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/configuration/backups): seamless integration with blob storage in AWS, Azure, and GCS.
    8. [Index Types ![external link](/content/imgs/external_link.png)](https://weaviate.io/developers/weaviate/concepts/vector-index): HNSW, HNSW compression, Quantization, FLAT, Asynchronous Indexing
2. **Milvus:** [Cloud-native vector database ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/v2.0.x/architecture_overview.md). Supports CLI and SDKs in Python, Java, Go & NodeJS.
    1. Query Performance: query performance depends onhardware environment, system parameters, indexes, and query scale and hence tuning of query performance can be done by changing or selecting the right configuration and is explained [here ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/v1.0.0/tuning.md#Tune-query-performance). [Performance FAQ ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/v1.0.0/performance_faq.md) provides details on different performance related queries and how to mitigate.
    2. [Scalability ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/v2.0.x/scaleout.md) : supports horizontal scaling of components.
    3. Search Types: [Vector Search ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/v2.0.x/search.md) and [Hybrid Search ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/v2.0.x/hybridsearch.md) (vector Search with attribute filtering)
    4. [Storage ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/v2.0.x/four_layers.md#Storage): meta storage, log broker and object storage.
    5. [Index types: ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/v2.0.x/index.md) FLAT, IVF\_FLAT, IVF\_SQ8, IVF\_PQ, HNSW, RHNSW\_FLAT, RHNSW\_SQ, RHNSW\_PQ, ANNOY.
    6. Multitenancy: Multitenancy can be achieved through three methods: [Database Oriented multitenancy, Collection-oriented multitenancy and Partition-oriented multitenancy. ![external link](/content/imgs/external_link.png)](https://milvus.io/docs/multi_tenancy.md)
3. **Qdrant:** Open-source withCloud as well as docker image offering. High level architecture can be seen [here ![external link](/content/imgs/external_link.png)](https://qdrant.tech/documentation/overview/#high-level-overview-of-qdrants-architecture). Supports Python, Rust, Go, Typescript. & Rest API
    1. Query Performance: The query performance depends on the right choice of the vCPUs and memory based on the size of the dataset. The capacity and sizing for optimal cluster configuration with different cases are described [here ![external link](/content/imgs/external_link.png)](https://qdrant.tech/documentation/cloud/capacity-sizing/). The benchmarking measured on the requests per second (RPS), latency, P95 latency and Index time on Single node and RPS vs Precision in Filtered search are captured [here ![external link](/content/imgs/external_link.png)](https://qdrant.tech/benchmarks/). Comparisons with a few other databases on these metrics are also available.
    2. [Scalability ![external link](/content/imgs/external_link.png)](https://qdrant.tech/documentation/cloud/cluster-scaling/): Supports vertical scaling and Horizontal scaling.
    3. [Search Types ![external link](/content/imgs/external_link.png)](https://qdrant.tech/documentation/concepts/search/): Vector Search, Exact (text) search with and without filters.
    4. [Storage ![external link](/content/imgs/external_link.png)](https://qdrant.tech/documentation/concepts/storage/#vector-storage): in-memory and Memmap (Disk) Storage
    5. Index Types: Graph based (HNSW) & [Quantization methods ![external link](/content/imgs/external_link.png)](https://qdrant.tech/documentation/guides/distributed_deployment/)
    6. [Multitenancy ![external link](/content/imgs/external_link.png)](https://qdrant.tech/documentation/guides/multiple-partitions/): can be configured using single collection with payload partitioning or creating multiple collections.
    7. [Distributed Deployment ![external link](/content/imgs/external_link.png)](https://qdrant.tech/documentation/guides/distributed_deployment/) : Supports distributed deployment mode.
1. **Azure AI search:** Enterprise ready PaaS offering on Azure. Supports C#, Java, JavaScript, Python, Rest API. Supports [Integrated Vectorization ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/vector-search-integrated-vectorization) is supported (chunking +vectorization)
    1. Query performance depends on [Index composition (schema and size) ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-performance-tips#index-size-and-schema), [Query design ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-performance-tips#query-design), [Service capacity ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-performance-tips#service-capacity) (tier, and the number of replicas and partitions).
    2. [Scalability ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-modeling-multitenant-saas-applications#scalability): can scale in two dimensions- storage and availability. Adding partitions and replicas will allow the capacity of the search service to grow with the amount of data and traffic. Adding partitions will increase the storage of a search service and adding replicas will increase the throughput of the requests.
    3. Search Types: [Full text ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-lucene-query-architecture), [Vector ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/vector-search-overview), [hybrid ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/hybrid-search-overview). Additionally, there is another offering of [Sematic Search ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/hybrid-search-how-to-query#semantic-hybrid-search) on the full text search through Semantic Configuration. There are a bunch of [other query types ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-query-overview) supported. Vector search also supports [multimodal search and multilingual search. ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/vector-search-overview#what-scenarios-can-vector-search-support)
    4. Storage: Structure of Index is an internal implementation with clusters (indexes, [shards and other files and folders ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-capacity-planning#concepts-search-units-replicas-partitions-shards)) managed by Microsoft.
    5. Index types: Vector Search ([Exhaustive k-NN, HNSW ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/vector-search-ranking#scope-of-a-vector-search))
    6. Multitenancy: can be achieved in different ways.
        1. [**One index per tenant** ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-modeling-multitenant-saas-applications#model-1-one-index-per-tenant) where multiple tenants use a single AI search service with each tenant with their own index. (For smaller tenants, there is an option called [High Density ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-modeling-multitenant-saas-applications#s3-high-density) which helps in increasing maximum number of indexes that a single service can host. The service and index limits in Azure AI search can be found [here ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-modeling-multitenant-saas-applications#service-and-index-limits-in-azure-ai-search).
        2. [**One service per tenant:** ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-modeling-multitenant-saas-applications#model-2-one-service-per-tenant)Each tenant has their own search service.
        3. [Hybrid ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-modeling-multitenant-saas-applications#model-3-hybrid): where largest tenants will have dedicated search services and the less active, smaller tenants will use shared services with index of their own.
    7. Reliability: best practices on handling resiliency and high availability are discussed [here ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/azure/search/search-reliability).

The following table offers an overview of common vector databases across a range of characteristics. It helps in evaluating and comparing these databases based on various technical and operational aspects.




| Characteristic / Vector DB|Database Type|Storage Engine|Indexing Mechanism|Query Capabilities|Scalability|Performance|Supported Data Types|Integration and Compatibility|Security Features|Ease of Use|Community and Support|Licensing and Pricing|High Availability and Disaster Recovery|Customization and Extensibility|
|:----|:----|:----|:----|:----|:----|:----|:----|:----|:----|:----|:----|:----|:----|:----|
|Pinecone|Vector database|Cloud-native, Kubernetes|FAISS, hybrid search|Nearest neighbor, filtered|Billions of vectors|Low latency, high speed|Dense, sparse vectors|ML frameworks, cloud|Metadata key-value pairs|Simple API, user-friendly|Community support|Managed service|Cloud-native, managed|API for CRUD operations|
|Milvus|Vector database|Separates storage and compute|ANNS, multiple index types|Similarity search, DML/DDL|Horizontal scalability|Blazing fast, hardware efficient|Dense, sparse vectors|ML models, diverse environments|Isolated system components|Intuitive SDKs, easy setup|Extensive community, GitHub|Open-source, Apache 2.0 license|High availability, resilient|Flexible, feature-rich|
|Faiss by Meta|Library for similarity search|In-memory, GPU support|Various indexing methods (HNSW, PQ, etc.)|Nearest-neighbor search|Scalable on large datasets|High-performance, especially on GPU|High-dimensional vectors|C++/Python interfaces, integrates with machine learning frameworks|Not specified|User-friendly, with Python and C++ support|Extensive community and support|Open-source|GPU support enhances availability|Highly customizable, supports various algorithms|
|Chroma DB|Vector database|Not specified|Not specified|Search, filtering, query by embeddings or texts|Not specified|Not specified|Embeddings, metadata|Integrates with LangChain, LlamaIndex, OpenAI|Not specified|Simple API for Python and JavaScript|Not specified|Open-source (Apache 2.0 license)|Not specified|Not specified|
|Vald|Distributed vector DBMS|Cloud-Native architecture|Fastest ANN Algorithm NGT|Approximate nearest neighbor search|Highly scalable, distributed|Fast, distributed search engine|Dense vectors|Supports multiple languages (Golang, Java, Node.js, Python)|Customizable Ingress/Egress filtering|Easy to install and use|Active GitHub repository, Slack community|Open-source (Apache 2.0 license)|Auto Indexing Backup, Index Replication|Highly customizable, can configure vector dimensions, replicas|
|Vespa|Vector database|Distributed, scalable|ANN, lexical, structured|Search, recommendation, AI|Large datasets, high loads|Low-latency, high-performance|Structured, text, vector|Machine learning support|Secured, customizable|Customizable, extendable|Extensive documentation|Open Source, Apache 2.0|High availability, reliability|Application components, ML|
|Elasticsearch|Vector database|Lucene-based, disk storage|Lucene HNSW, ANN|Hybrid retrieval, ANN, kNN|Scales beyond RAM size|Efficient, scalable search|Unstructured, semi-structured|ML, Elastic Stack integration|Indexing, searching security|Powerful APIs, user-friendly|Robust community, support|Open Source, commercial|Incremental snapshots, reliable|Flexible APIs, integrations|
|Deep Lake|Vector database|Multi-modal, serverless|Tensor-based, multi-modal|Embedding, metadata, multi-modal|High-performance, scalable|Fast streaming, query execution|All AI data types, multi-modal|PyTorch, TensorFlow, LangChain|Data versioning, secure storage|Python API, easy setup|Community-driven, active support|Open Source, MPL-2.0|Serverless, efficient data handling|Customizable, multi-modal support|
|Qdrant|Vector database|Cloud-native|HNSW algorithm|Nearest neighbors, filterable|Scales horizontally|Fast and accurate|Various data types|API in many languages|Not specified|Easy to use API|GitHub community|Open-source|Not specified|Payload filtering, custom logic|
|Weaviate|Vector database|Cloud-native|HNSW algorithm|Vector and scalar search|Horizontally scalable|Fast queries|Text, images, etc.|GraphQL, REST, language clients|Not specified|User-friendly|GitHub community|Open-source|High availability (roadmap)|Modules, custom models|
|Azure AI Search|Cloud-based vector database|Azure infrastructure|Vector fields, embedding models|Text, image, multilingual, hybrid|Scalable service|High-performance|Text, images, various|Azure services integration|Azure security features|Simplified wizard setup|Azure community, support|Azure pricing model|Azure reliability|Configurable, chunking strategy|


[Microsoft Copilot Studio ![external link](/content/imgs/external_link.png)](https://www.microsoft.com/microsoft-copilot/microsoft-copilot-studio)  is a Platform-as-a-Service (PaaS) offering that enables the development of AI-powered virtual agents and bots using a no-code/low-code approach. It provides a visual interface for building and deploying virtual agents that can be seamlessly integrated with existing applications and services.

> Please note that you may come across documentation referring to Power Virtual Agent instead of Microsoft Copilot Studio. It's important to highlight that Power Virtual Agent is the previous name for Microsoft Copilot Studio.

Copilot Studio is built on top of Power Virtual Agents, which is a low-code/no-code platform specifically designed for creating chatbots and virtual agents. By leveraging Copilot Studio, customers can benefit from its deep integration with Microsoft services, allowing easy access to data from various sources and formats.

While Copilot Studio offers significant value, it does require some learning curve, particularly in adopting DevOps practices. However, as part of the Power Platform family, Copilot Studio inherits features such as common user management, application lifecycle management (ALM) practices, data loss prevention, and security features. So people with Power Platform experience can quickly start using Copilot Studio.

### Learning resources

- [Microsoft Copilot Studio Demo – Microsoft Ignite 2023 (10m) ![external link](/content/imgs/external_link.png)](https://www.youtube.com/watch?v=5buwz0Gruc4) and recent Ignite session - [Transform copilot development with Microsoft Copilot Studio ![external link](/content/imgs/external_link.png)](https://ignite.microsoft.com/en-US/sessions/6f38dfc6-97eb-4d8d-8972-8c0a2a20c0d8?source=sessions)

- To get started with Copilot Studio, it is recommended to refer to [The Bot Building Handbook ![external link](/content/imgs/external_link.png)](https://aka.ms/PVAPlaybook) ([copy of the playbook in this repo](/content/PVA%20Bot%20Building%20Handbook.pdf)). The playbook provides structure and guidance for implementing a large chatbot project based on Microsoft Copilot Studio. It includes best practices and learnings from real-world engagements with enterprise customers. The document is aimed at project leads, architects, and development leads, offering project approach recommendations and technical information. Following this guidance will help teams mitigate risk, understand trade-offs, and measure success.

- [The Microsoft Copilot Studio Architecture Series ![external link](/content/imgs/external_link.png)](https://aka.ms/pvaarchitectureseries) is a valuable resource for chatbot projects. It covers various considerations and topics, including:

    - Planning and Building your first chatbot
    - Extending your PVA chatbot with the Power Platform or Bot Framework
    - Advanced topics, Security and Governance.

- [Create copilots with Microsoft Copilot Studio ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-gb/training/paths/power-virtual-agents-workshop/) In this learning path you'll complete hands on activities using Microsoft Power Platform, specifically Microsoft Copilot Studio and Power Automate.
- To learn about Application Lifecycle Management, please refer to the official documentation on [ALM for Developers ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/power-platform/alm/alm-for-developers). ALM is a critical aspect that poses challenges not only for ISVs but also for managing the lifecycle within an Azure Enterprise Tenant.
- ISVs that are planning to distribute copilot could find valuable features in [Microsoft Power Platform ISV Studio ![external link](/content/imgs/external_link.png)](https://learn.microsoft.com/en-us/power-platform/developer/isvstudio/)
- Details about pricing of the Microsoft Copilot Studio offers can be found in the [Microsoft Power Platform Licensing Guide ![external link](/content/imgs/external_link.png)](https://go.microsoft.com/fwlink/?linkid=2085130).

- You can also find more information about Copilot Studio at the following official resources:
    - [Copilot Studio website ![external link](/content/imgs/external_link.png)](https://aka.ms/copilotstudio)
    - [Blog ![external link](/content/imgs/external_link.png)](https://aka.ms/copilotstudioblog)
    - [Product documentation ![external link](/content/imgs/external_link.png)](https://aka.ms/copilotstudiodocs)
    - [Community page ![external link](/content/imgs/external_link.png)](https://aka.ms/copilotstudiocommunity)

--------------------------------------------