using System.Threading.Tasks;

namespace Google.Maps.DistanceMatrix
{
	public interface IDistanceMatrixService
	{
		DistanceMatrixResponse GetResponse(DistanceMatrixRequest request);
		Task<DistanceMatrixResponse> GetResponseAsync(DistanceMatrixRequest request);
	}
}