# TranscriptConnector
A custom Power Platform connector to retrieve meeting transcripts from Microsoft Graph

## Prerequisites

### Entra ID App Registration with following API permissions

| API permission       | Type       | Description       | Admin Consent required       |
|-----------------|----------------|----------------|----------------|
| Calendars.Read  | Delegated  | Read user calendars  | No  |
| OnlineMeetings.Read  | Delegated  | Read user's online meetings  | No  |
| OnlineMeetingTranscript.Read.All  | Delegated  | Read all transcripts of online meetings  | Yes  |
| User.Read  | Delegated  | Sign in and read user profile  | No  |

## Operations

The `TranscriptConnector` provides the following operations:

1. **Get Meeting Transcripts**  
    Retrieves the transcript of a specified online meeting using its meeting ID.

2. **List User Meetings**  
    Fetches a list of online meetings for the authenticated user within a specified time range.

3. **Get Meeting Details**  
    Retrieves detailed information about a specific online meeting using its meeting ID.

4. **Search Transcripts**  
    Allows searching for specific keywords or phrases within the transcripts of online meetings.

5. **Download Transcript File**  
    Downloads the transcript file of a specified online meeting in the available format.


## Custom Code Implementation

The custom code in the connector ensures that the web/vtt transcript returned by the Microsoft Graph API is transformed into a JSON object for easier consumption. Below is an overview of the implemented logic:

1. **Transforming the Response**  
    The `TransformResponse` method intercepts the HTTP response from the Graph API. If the response is successful, it reads the plain text content of the transcript and wraps it into a JSON object with a single key, `transcript`.

2. **Code Snippet**  
    The following code snippet demonstrates the transformation logic:

    ```csharp
    public class Script : ScriptBase
    {
         public override async Task<HttpResponseMessage> ExecuteAsync()
         {
              return await this.TransformResponse().ConfigureAwait(false);
         }

         private async Task<HttpResponseMessage> TransformResponse()
         {
              HttpResponseMessage response = await this.Context.SendAsync(this.Context.Request, this.CancellationToken).ConfigureAwait(false);

              if (response.IsSuccessStatusCode)
              {
                    var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var newResult = new JObject
                    {
                         ["transcript"] = responseString,
                    };
                    response.Content = CreateJsonContent(newResult.ToString());
              }

              return response;
         }
    }
    ```

This ensures that the transcript data is returned in a structured JSON format, making it easier for downstream applications to process.
