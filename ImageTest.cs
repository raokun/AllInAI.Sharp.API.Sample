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
    public class ImageTest {
        #region OpenAI
        [TestMethod()]
        public async Task OpenAIImgTest() {
            AuthOption authOption = new AuthOption() { Key = "<YOUR-KEY>", BaseUrl = "https://api.openai.com", AIType = Enums.AITypeEnum.OpenAi };

            ImgService imgService = new ImgService(authOption);
            Txt2ImgReq imgReq = new Txt2ImgReq();
            imgReq.Steps = 20;
            imgReq.Size = "1024x1024";
            imgReq.N = 1;
            imgReq.Prompt = "kitty";
            imgReq.ResponseFormat = "b64_json";
            ImgRes imgRes = await imgService.Txt2Img(imgReq);
            if (imgRes.Error != null) {
                Console.WriteLine(imgRes.Error.Message);
            }
            else {
                if (imgRes.Results.Count > 0) {
                    foreach (var item in imgRes.Results) {
                        var filePath = $"D:/test/{Guid.NewGuid()}.png";
                        var imageData = Convert.FromBase64String(item.B64);
                        await System.IO.File.WriteAllBytesAsync(filePath, imageData);
                    }
                }
                Console.WriteLine(imgRes);
            }
        }
        #endregion
        #region Baidu SDXL
        [TestMethod()]
        public async Task BaiduImgTest() {
            try {
                AuthService authService = new AuthService("https://aip.baidubce.com");
                var token = await authService.GetTokenAsyncForBaidu("<API Key>", "<Secret Key>");
                AuthOption authOption = new AuthOption() { Key = token.access_token, BaseUrl = "https://aip.baidubce.com", AIType = Enums.AITypeEnum.Baidu };

                ImgService imgService = new ImgService(authOption);
                Txt2ImgReq imgReq = new Txt2ImgReq();
                imgReq.Steps = 20;
                imgReq.Size = "1024x1024";
                imgReq.N = 1;
                imgReq.Prompt = "kitty";
                imgReq.ResponseFormat = "b64_json";
                ImgRes imgRes = await imgService.Txt2Img(imgReq);
                if (imgRes.Error != null) {
                    Console.WriteLine(imgRes.Error.Message);
                }
                else {
                    if (imgRes.Results.Count > 0) {
                        foreach (var item in imgRes.Results) {
                            var filePath = $"D:/test/{Guid.NewGuid()}.png";
                            var imageData = Convert.FromBase64String(item.B64);
                            await System.IO.File.WriteAllBytesAsync(filePath, imageData);
                        }
                    }
                    Console.WriteLine(imgRes);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
        #region stable diffusion
        [TestMethod()]
        public async Task SDImgTest() {
            try {

                AuthOption authOption = new AuthOption() { BaseUrl = "http://43.134.164.127:777", AIType = Enums.AITypeEnum.SD };
                ImgService imgService = new ImgService(authOption);
                Txt2ImgReq imgReq = new Txt2ImgReq();
                imgReq.Steps = 20;
                imgReq.Size = "1024x1024";
                imgReq.N = 1;
                imgReq.Prompt = "kitty";
                imgReq.ResponseFormat = "b64_json";
                ImgRes imgRes = await imgService.Txt2Img(imgReq);
                if (imgRes.Error != null) {
                    Console.WriteLine(imgRes.Error.Message);
                }
                else {
                    if (imgRes.Results.Count > 0) {
                        foreach (var item in imgRes.Results) {
                            var filePath = $"D:/test/{Guid.NewGuid()}.png";
                            var imageData = Convert.FromBase64String(item.B64);
                            await System.IO.File.WriteAllBytesAsync(filePath, imageData);
                        }
                    }
                    Console.WriteLine(imgRes);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
        #region midjourney 
        #endregion
    }
}
