using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hack2025_LegalAlchemists
{
    public class MatterPlugin
    {
        [KernelFunction("get_matters")]
        [Description("Gets all matter informations")]
        [return: Description("A list of Matter With MatterReferenceNo")]

        public async Task<List<Matter>> GetNews(Kernel kernel, string category)
        {

            var data = new List<Matter>();
            var client = new HttpClient();

            var requestUrl = "https://alcm-test.accesslegal.accessacloud.com/webService2/api/Matters/GetMatters?suppressErrors=true";

            var requestBody = new
            {
                matterFilterOptionViewModel = new
                {
                    departmentId = (int?)null,
                    isInactiveFeeearners = false,
                    isOnlyOpen = true,
                    matterFilterType = "Recent50",
                    isGeneralSearch = true,
                    searchText = (string)null,
                    user = "DLJ"
                },
                dataSourceRequestViewModel = new
                {
                    take = 4,
                    filter = (object)null,
                    skip = 0,
                    sort = (object)null
                }
            };

            var jsonBody = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "<Your JWT Token Here>");
            client.DefaultRequestHeaders.Add("dps-selected-database", "9974e28d-597c-4e11-9536-b79c9a56e013");

            var response = await client.PostAsync(requestUrl, content);
            var responseString = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseString, options);

            if (apiResponse?.Data?.Data != null)
            {
                foreach (var matter in apiResponse.Data.Data)
                {
                    Console.WriteLine($"Matter Ref: {matter.MatterReferenceNo}, Client: {matter.ClientName}, Details: {matter.MatterDetails}");
                }
            }
            else
            {
                Console.WriteLine("No matter data found.");
            }

            return apiResponse?.Data?.Data;
        }

    }
}
