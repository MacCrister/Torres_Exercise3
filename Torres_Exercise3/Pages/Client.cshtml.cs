using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torres_Exercise3.Models;

namespace Torres_Exercise3.Pages
{
    public class ClientModel : PageModel
    {
        public ClientModel(TorresCafeDBContext registrationcontext)
        {
            _torresCafeDBContext = registrationcontext;
        }
        private readonly TorresCafeDBContext _torresCafeDBContext;
        [BindProperty]
        public Client Client { get; set; }

        public List<Client> Clients = new List<Client>();

        public void OnGet()
        {
            Clients = _torresCafeDBContext.Clients.ToList();
        }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Clients = _torresCafeDBContext.Clients.ToList();
                return Page();
            }
            _torresCafeDBContext.Clients.Add(Client);
            _torresCafeDBContext.SaveChanges();
            return Redirect("/index");
        }
    }
}
