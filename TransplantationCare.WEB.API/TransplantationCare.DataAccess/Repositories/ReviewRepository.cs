using TransplantationCare.Core.Interfaces.Repositories;
using TransplantationCare.Core.Models.DataBase;

namespace TransplantationCare.DataAccess.Repositories
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(TransplantationCareContext context) : base(context)
        { }
    }
}
