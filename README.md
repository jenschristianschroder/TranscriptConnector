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

### Operations

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
