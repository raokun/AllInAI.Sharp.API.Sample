<div align="center">
	<h1>AllInAI.Sharp.API.Sample</h1>
</div>

![](https://img.shields.io/github/stars/raokun/AllInAI.Sharp.API.Sample) ![](https://img.shields.io/github/forks/raokun/AllInAI.Sharp.API.Sample)

English | [中文简介](README-CN.md)


Usage example documentation for AllInAI.Sharp.API.
AllInAI.Sharp.API is an SDK that calls language models from various platforms, and it helps users quickly integrate with major models. It has integrated OpenAI, chatGLM, Wenxin Qianfan, Synonymous Qianwen, stable-diffusion, etc. It supports setting reverse proxies and streaming interfaces.
The AllInAI SDK integrates unified input and output parameters in the chat and image interfaces, making it easy to call.

## Version
```
V1.1.3 Fix the issue of Wenxin Qianfan model
V1.1.2 Fix the issue of empty return when calling the Wenxin Qianfan model
```

## Completed models include:
* OpenAI
* chatGLM
* Wenxin Qianfan
* Synonymous Qianwen
* stable-diffusion

## Usage example
### Initiate a chat

1. Set the basic configurations:
   - key: The model secret key
   - BaseUrl: The proxy address
   - AIType: The model type, corresponds to the Enums.AITypeEnum enumeration

2. Call the API
1. chat
```c#
AuthOption authOption = new AuthOption() { Key = "sk-***", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };

ChatService chatService = new ChatService(authOption);
CompletionReq completionReq = new CompletionReq();
List<MessageDto> messages = new List<MessageDto>();
messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
completionReq.Model = "gpt-3.5-turbo";
completionReq.Messages = messages;
CompletionRes completionRes = await chatService.Completion(completionReq);
```
2. image
```c#
AuthOption authOption = new AuthOption() {BaseUrl = "http://43.134.164.127:77", AIType = Enums.AITypeEnum.SD };
ImgService imgService = new ImgService(authOption);
Txt2ImgReq imgReq = new Txt2ImgReq();
imgReq.Steps = 20;
imgReq.Size = "1024x1024";
imgReq.N = 1;
imgReq.Prompt = "kitty";
imgReq.ResponseFormat = "b64_json";
ImgRes imgRes = await imgService.Txt2Img(imgReq);
```

## How to contribute
1. Fork & Clone
2. Create a branch named Feature/name(your github id)/issuexxx
3. Commit with a commit message, like "solve issue xxx, add xxx"
4. Create a Pull Request
If you would like to contribute, feel free to submit Pull Requests or give us Issues.

## Donation

If you find this project helpful, you can buy raokun a coffee to show support. raokun's open-source contribution relies on your support and encouragement.
  <div style="display:flex;">
  	<div style="padding-right:24px;">
  		<p>WeChat</p>
      <img src="https://www.raokun.top/upload/2023/04/%E5%BE%AE%E4%BF%A1%E6%94%B6%E6%AC%BE.jpg" style="width:200px" />
  	</div>
	<div style="padding-right:24px;">
  		<p>Alipay</p>
      <img src="https://www.raokun.top/upload/2023/04/%E6%94%AF%E4%BB%98%E5%AE%9D%E6%94%B6%E6%AC%BE.jpg" style="width:200px" />
  	</div>
  </div>

