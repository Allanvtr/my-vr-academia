using System;
using System.Collections.Generic;

[Serializable]
public class StatusResponse
{
    public string operationId;
    public string status;
    public List<string> audioUrl;
}