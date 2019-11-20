using Project_SEM2_HNDShop.Data;

namespace Project_SEM2_HNDShop.Services
{
    public class Repository
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }
    }
}