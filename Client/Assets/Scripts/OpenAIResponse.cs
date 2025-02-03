using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class OpenAIResponse
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("object")]
    public string ObjectType { get; set; }

    [JsonProperty("created")]
    public long Created { get; set; }

    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("choices")]
    public List<Choice> Choices { get; set; }

    [JsonProperty("usage")]
    public Usage Usage { get; set; }

    [JsonProperty("service_tier")]
    public string ServiceTier { get; set; }

    [JsonProperty("system_fingerprint")]
    public string SystemFingerprint { get; set; }
}

[Serializable]
public class Choice
{
    [JsonProperty("index")]
    public int Index { get; set; }

    [JsonProperty("message")]
    public Message Message { get; set; }

    [JsonProperty("logprobs")]
    public object Logprobs { get; set; }

    [JsonProperty("finish_reason")]
    public string FinishReason { get; set; }
}

[Serializable]
public class Message
{
    [JsonProperty("role")]
    public string Role { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("refusal")]
    public object Refusal { get; set; }
}

[Serializable]
public class Usage
{
    [JsonProperty("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonProperty("completion_tokens")]
    public int CompletionTokens { get; set; }

    [JsonProperty("total_tokens")]
    public int TotalTokens { get; set; }

    [JsonProperty("prompt_tokens_details")]
    public TokenDetails PromptTokensDetails { get; set; }

    [JsonProperty("completion_tokens_details")]
    public TokenDetails CompletionTokensDetails { get; set; }
}

[Serializable]
public class TokenDetails
{
    [JsonProperty("cached_tokens")]
    public int CachedTokens { get; set; }

    [JsonProperty("audio_tokens")]
    public int AudioTokens { get; set; }

    [JsonProperty("reasoning_tokens")]
    public int ReasoningTokens { get; set; }

    [JsonProperty("accepted_prediction_tokens")]
    public int AcceptedPredictionTokens { get; set; }

    [JsonProperty("rejected_prediction_tokens")]
    public int RejectedPredictionTokens { get; set; }
}
