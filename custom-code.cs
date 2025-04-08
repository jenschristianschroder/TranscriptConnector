public class Script : ScriptBase
{

    public override async Task<HttpResponseMessage> ExecuteAsync()
    {
        return await this.TransformResponse().ConfigureAwait(false);
    }

    private async Task<HttpResponseMessage> TransformResponse()
    {
        // Use the context to forward/send an HTTP request
        HttpResponseMessage response = await this.Context.SendAsync(this.Context.Request, this.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);

        // Do the transformation if the response was successful, otherwise return error responses as-is
        if (response.IsSuccessStatusCode)
        {
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
            
            
            // Wrap the original JSON object into a new JSON object with just one key ('wrapped')
            var newResult = new JObject
            {
                ["transcript"] = responseString,
            };
            
            response.Content = CreateJsonContent(newResult.ToString());
        }

        return response;
    }
}
