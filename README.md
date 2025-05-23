# AIChat

A simple C# console application using [Microsoft Semantic Kernel](https://github.com/microsoft/semantic-kernel) and OpenAI to provide an interactive AI chat experience.

## Features

- Streams AI chat completions from OpenAI models (e.g., GPT-4o)
- Loads configuration (API key, endpoint, model name) from `appsettings.json`
- Keeps chat history for context-aware conversations
- Designed for extensibility and best practices

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- An OpenAI-compatible endpoint and API key

### Setup

1. **Clone the repository:**
   ```sh
   git clone <your-repo-url>
   cd SemanticKernel/AIChat
   ```

2. **Create `appsettings.json` in the `AIChat` directory:**
   ```json
   {
     "OpenAI": {
       "Token": "your_openai_api_key",
       "Endpoint": "https://your-openai-endpoint",
       "ModelName": "gpt-4o"
     }
   }
   ```
   > **Note:** `appsettings.json` is excluded from version control via `.gitignore`.

3. **Restore dependencies:**
   ```sh
   dotnet restore
   ```

4. **Build and run:**
   ```sh
   dotnet run
   ```

### Usage

- Type your question at the `Q:` prompt and press Enter.
- The AI will respond in real time.
- To exit, use `Ctrl+C`.

## Project Structure

- `Program.cs` – Main application logic and chat loop
- `appsettings.json` – Configuration file (not committed to source control)
- `.gitignore` – Ensures secrets/config files are not tracked

## Security

- **Never commit your API keys or secrets.**
- `appsettings.json` is in `.gitignore` by default.

## License

MIT

---

**Happy chatting!**