import os

from dotenv import load_dotenv, find_dotenv
_ = load_dotenv(find_dotenv())

# print(os.getenv('OPENAI_API_KEY'))

from langchain.llms import AzureOpenAI
from langchain.chat_models import ChatOpenAI

# llm = ChatOpenAI(openai_api_key=OPENAI_API_KEY)

llm = AzureOpenAI(
    deployment_name="dep2" #text-davinci-003
)

text = "What would be a good company name for a company that makes colorful socks? Please provide only one option and no other instructions."

print("###############################")
result = llm.invoke(text)
print(text)
print("##")
print(result)
print("###############################")

