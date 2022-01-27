﻿namespace Application.Wrappers;

/***
 * This is only a generic class for wrap the response from a command or a query in the CQRS pattern
 * this will holds a generic type, so this will act as a response for a web api
 */
public class Response<T>
{
    public Response()
    {
        
    } 
    
    public Response(T data, string message=null)
    {
        Success = true;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        Success = false;
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }


}