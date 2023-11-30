using AllInAI.Sharp.API.Constant;
using AllInAI.Sharp.API.Dto;
using AllInAI.Sharp.API.Req;
using AllInAI.Sharp.API.Res;
using AllInAI.Sharp.API.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllInAI.Sharp.API.Sample {
    [TestClass()]
    public class ChatTest {
        #region OpenAI
        [TestMethod()]
        public async Task OpenAICompletionTest() {
            AuthOption authOption = new AuthOption() { Key = "<YOUR-KEY>", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };

            ChatService chatService = new ChatService(authOption);
            CompletionReq completionReq = new CompletionReq();
            List<MessageDto> messages = new List<MessageDto>();
            messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
            completionReq.Model = "gpt-3.5-turbo";
            completionReq.Messages = messages;
            CompletionRes completionRes = await chatService.Completion(completionReq);
            if (completionRes.Error != null) {
                Console.WriteLine(completionRes.Error.Message);
            }
            else {
                Console.WriteLine(completionRes);
            }
        }

        [TestMethod()]
        public async Task OpenAICompletionStreamTest() {
            AuthOption authOption = new AuthOption() { Key = "<YOUR-KEY>", BaseUrl = "http://43.134.164.127:4150/", AIType = Enums.AITypeEnum.OpenAi };
            ChatService chatService = new ChatService(authOption);
            CompletionReq completionReq = new CompletionReq();
            List<MessageDto> messages = new List<MessageDto>();
            messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
            completionReq.Model = "gpt-3.5-turbo";
            completionReq.Messages = messages;
            var enumerable = chatService.CompletionStream(completionReq);
            //接口返回的完整内容
            string totalMsg = "";
            await foreach (var item in enumerable) {
                totalMsg += item.Result;
            }
        }
        #endregion
        #region 文心一言
        [TestMethod()]
        public async Task BaiduCompletionTest() {
            AuthService authService = new AuthService("https://aip.baidubce.com");
            var token = await authService.GetTokenAsyncForBaidu("<API Key>", "<Secret Key>");
            AuthOption authOption = new AuthOption() { Key = token.access_token, BaseUrl = "https://aip.baidubce.com", AIType = Enums.AITypeEnum.Baidu };

            ChatService chatService = new ChatService(authOption);
            CompletionReq completionReq = new CompletionReq();
            List<MessageDto> messages = new List<MessageDto>();
            messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
            completionReq.Model = BaiduModels.Qianfan_BLOOMZ_7B_compressed;
            completionReq.Messages = messages;
            CompletionRes completionRes = await chatService.Completion(completionReq);
            if (completionRes.Error != null) {
                Console.WriteLine(completionRes.Error.Message);
            }
            else {
                Console.WriteLine(completionRes);
            }
        }
        [TestMethod()]
        public async Task BaiduCompletionStreamTest() {
            AuthService authService = new AuthService("https://aip.baidubce.com");
            var token = await authService.GetTokenAsyncForBaidu("<API Key>", "<Secret Key>");
            AuthOption authOption = new AuthOption() { Key = token.access_token, BaseUrl = "https://aip.baidubce.com", AIType = Enums.AITypeEnum.Baidu };

            ChatService chatService = new ChatService(authOption);
            CompletionReq completionReq = new CompletionReq();
            List<MessageDto> messages = new List<MessageDto>();
            messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
            completionReq.Model = BaiduModels.ERNIE_Bot_turbo_AI;
            completionReq.Messages = messages;
            var enumerable = chatService.CompletionStream(completionReq);
            //接口返回的完整内容
            string totalMsg = "";
            await foreach (var item in enumerable) {
                totalMsg += item.Result;
            }
        }
        #endregion
        #region 同义千问
        [TestMethod()]
        public async Task AliCompletionTest() {

            AuthOption authOption = new AuthOption() { Key = "<YOUR-KEY>", BaseUrl = " https://dashscope.aliyuncs.com", AIType = Enums.AITypeEnum.Ali };

            ChatService chatService = new ChatService(authOption);
            CompletionReq completionReq = new CompletionReq();
            List<MessageDto> messages = new List<MessageDto>();
            messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
            completionReq.Model = "qwen-turbo";
            completionReq.Messages = messages;
            CompletionRes completionRes = await chatService.Completion(completionReq);
            if (completionRes.Error != null) {
                Console.WriteLine(completionRes.Error.Message);
            }
            else {
                Console.WriteLine(completionRes);
            }
        }

        [TestMethod()]
        public async Task AliCompletionStreamTest() {

            AuthOption authOption = new AuthOption() { Key = "<YOUR-KEY>", BaseUrl = " https://dashscope.aliyuncs.com", AIType = Enums.AITypeEnum.Ali };

            ChatService chatService = new ChatService(authOption);
            CompletionReq completionReq = new CompletionReq();
            List<MessageDto> messages = new List<MessageDto>();
            messages.Add(new MessageDto() { Role = "user", Content = "Hello!" });
            completionReq.Model = "qwen-turbo";
            completionReq.Messages = messages;
            var enumerable = chatService.CompletionStream(completionReq);
            //接口返回的完整内容
            string totalMsg = "";
            await foreach (var item in enumerable) {
                totalMsg += item.Result;
            }
        }
        #endregion
    }
}
