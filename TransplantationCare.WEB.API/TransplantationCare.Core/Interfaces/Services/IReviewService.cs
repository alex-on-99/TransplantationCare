using System.Threading.Tasks;
using TransplantationCare.Core.Models.Business;

namespace TransplantationCare.Core.Interfaces.Services
{
    public interface IReviewService
    {
        Task CreateReview(ReviewCreationModel reviewModel);
    }
}
