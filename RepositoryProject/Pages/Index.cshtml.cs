using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RepositoryProject.Models;
using RepositoryProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Cutomer> Cutomers { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async void OnGet()
        {
            Users =  await  _unitOfWork.Users.All();
            Cutomers = await _unitOfWork.Customers.All();

        }
    }
}
