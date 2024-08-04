namespace ResearchCruiseApp_API.Application.Services.Compressor;


public interface ICompressor
{
    public Task<byte[]> CompressAsync(string input);

    public Task<string> Decompress(byte[] input);
}