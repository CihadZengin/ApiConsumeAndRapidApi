using HotelProject.WepUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace HotelProject.WepUI.ViewComponents.DashBoard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();

            // Twitter isteği
            var twitterRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(""),
                Headers =
        {
            { "", "" },
            { "t", "" },
        },
            };

            var twitterResponse = await client.SendAsync(twitterRequest);
            twitterResponse.EnsureSuccessStatusCode();
            var twitterBody = await twitterResponse.Content.ReadAsStringAsync();
            var twitterDto = JsonConvert.DeserializeObject<ResultTwitterFollowersDto>(twitterBody);

            // Instagram isteği
            var instaRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(""),
                Headers =
        {
            { "", "" },
            { "", "" },
        },
            };

            var instaResponse = await client.SendAsync(instaRequest);
            instaResponse.EnsureSuccessStatusCode();
            var instaBody = await instaResponse.Content.ReadAsStringAsync();
            var instaDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(instaBody);

            // ViewBag doldur
            ViewBag.t1 = twitterDto.friends;
            ViewBag.t2 = twitterDto.sub_count;
            ViewBag.v1 = instaDto.followers;
            ViewBag.v2 = instaDto.following;

            // Ortak model oluştur
            var combinedModel = new
            {
                Twitter = twitterDto,
                Instagram = instaDto
            };

            return View(combinedModel);
        }
    }
}
