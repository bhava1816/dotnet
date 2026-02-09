public class ApiResponse<T>//tells the how over output is being coming
{
    public int Status { get; set; }
    public string Msg { get; set; } = string.Empty;
    public T Data { get; set; } = default!;
}
